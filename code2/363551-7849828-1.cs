	using System;
	using System.IO;
	using System.Text;
	using System.Runtime.InteropServices;
	unsafe class TestWriter
	{
		static void Main()
		{
				byte[] message = UnicodeEncoding.Unicode.GetBytes("Here is some data.");
				IntPtr memIntPtr = Marshal.AllocHGlobal(message.Length);
				byte* memBytePtr = (byte*) memIntPtr.ToPointer();
				UnmanagedMemoryStream writeStream = new UnmanagedMemoryStream(memBytePtr, message.Length, message.Length, FileAccess.Write);
				writeStream.Write(message, 0, message.Length);
				writeStream.Close();
				UnmanagedMemoryStream readStream = new UnmanagedMemoryStream(memBytePtr, message.Length, message.Length, FileAccess.Read);
				byte[] outMessage = new byte[message.Length];
				readStream.Read(outMessage, 0, message.Length);
				readStream.Close();
				Console.WriteLine(UnicodeEncoding.Unicode.GetString(outMessage));
				Marshal.FreeHGlobal(memIntPtr);
				Console.ReadLine();
		}
	}
