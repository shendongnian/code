    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    using System.Threading;
    namespace ConsoleDemo
    {
      class Program
      {
        static void Main(string[] args)
        {
          Thread t = new Thread(new ThreadStart(UpdateConsole));
          t.IsBackground=true;
          t.Start();      
          string input;
          do
          {
            Console.SetCursorPosition(0, 23);
            Console.Write("Command: ");
            input = Console.ReadLine();
            ConsoleBuffer.ClearArea(0, 21, 80, 3);
            Console.SetCursorPosition(0, 22);
            Console.Write(input);
          } while (!string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase));
        }
        static void UpdateConsole()
        {
          int i = 0;
          Random rnd = new Random();
          while (true)
          {
            string s = new string((char)(65 + (i % 26)),1);
            for (short x = 0; x < 80; ++x)
            {
              for (short y = 0; y < 20; ++y)
              {
                ConsoleBuffer.WriteAt(x, y, s);
                ConsoleBuffer.SetAttribute(x, y, (short)(rnd.Next(15)+1));
              }          
            }
            Thread.Sleep(500);
            i++;
          }
        }
      }
      public class ConsoleBuffer
      {
        private static SafeFileHandle _hBuffer = null;
    
        static ConsoleBuffer()
        {
          _hBuffer = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
      
          if (_hBuffer.IsInvalid)
          {
            throw new Exception("Failed to open console buffer");
          }      
        }
        public static void WriteAt(short x, short y, string value)
        {
          int n = 0;
          WriteConsoleOutputCharacter(_hBuffer, value, value.Length, new Coord(x, y), ref n);
        }
        public static void SetAttribute(short x, short y, short attr)
        {
          SetAttribute( x, y, new short[] { attr });
        }
        public static void SetAttribute(short x, short y, short[] attrs)
        {
          int n = 0;
          WriteConsoleOutputAttribute(_hBuffer, attrs, attrs.Length, new Coord(x, y), ref n);
        }
        public static void ClearArea(short left, short top, short width, short height, char ch = ' ')
        {
          ClearArea(left, top, width, height, new CharInfo() { Char = new CharUnion() { UnicodeChar = ch } });
        }
        public static void ClearArea(short left, short top, short width, short height)
        {
          ClearArea(left, top, width, height, new CharInfo() { Char = new CharUnion() { AsciiChar = 32 } });
        }
        private static void ClearArea(short left, short top, short width, short height, CharInfo charAttr)
        {
          CharInfo[] buf = new CharInfo[width * height];
          for (int i = 0; i < buf.Length; ++i)
          {
            buf[i] = charAttr;
          }
          SmallRect rect = new SmallRect() { Left = left, Top = top, Right = (short)(left + width), Bottom = (short)(top + height) };
          WriteConsoleOutput(_hBuffer, buf,
            new Coord() { X = width, Y = height },
            new Coord() { X = 0, Y = 0 },
            ref rect);      
        }
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
          string fileName,
          [MarshalAs(UnmanagedType.U4)] uint fileAccess,
          [MarshalAs(UnmanagedType.U4)] uint fileShare,
          IntPtr securityAttributes,
          [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
          [MarshalAs(UnmanagedType.U4)] int flags,
          IntPtr template);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutputCharacter(
          SafeFileHandle hConsoleOutput,
          string lpCharacter,
          int nLength,
          Coord dwWriteCoord,
          ref int lpumberOfCharsWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutputAttribute(
          SafeFileHandle hConsoleOutput,
          short[] lpAttributes,
          int nLength,
          Coord dwWriteCoord,
          ref int lpumberOfAttrsWritten);
        [StructLayout(LayoutKind.Sequential)]
        struct Coord
        {
          public short X;
          public short Y;
          public Coord(short X, short Y)
          {
            this.X = X;
            this.Y = Y;
          }
        };
        [StructLayout(LayoutKind.Explicit)]
        struct CharUnion
        {
          [FieldOffset(0)]
          public char UnicodeChar;
          [FieldOffset(0)]
          public byte AsciiChar;
        }
        [StructLayout(LayoutKind.Explicit)]
        struct CharInfo
        {
          [FieldOffset(0)]
          public CharUnion Char;
          [FieldOffset(2)]
          public short Attributes;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct SmallRect
        {
          public short Left;
          public short Top;
          public short Right;
          public short Bottom;
        }
      }
    }
 
