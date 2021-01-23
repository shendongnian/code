	using System;
	using System.Windows.Forms;
	using System.Runtime.InteropServices;
	namespace StackOverflow
	{
		static class Program
		{
			static void Main()
			{
				Application.Run(new Form1());
			}
		}
		public static class KeyboardRawInput
		{
			public struct RawKeyboard
			{
				public int Type;
				public int Size;
				public IntPtr Device;
				public IntPtr WParam;
				public ushort MakeCode;
				public ushort Flags;
				public ushort Reserved;
				public ushort VKey;
				public uint Message;
				public uint ExtraInformation;
			}
			public struct RawInputDevice
			{
				public ushort Page;
				public ushort Usage;
				public int Flags;
				public IntPtr HWnd;
			}
			[DllImport("user32", SetLastError = true)]
			public static extern bool RegisterRawInputDevices(
				[MarshalAs(UnmanagedType.LPArray)] RawInputDevice[] devs,
				uint count,
				int structSize);
			[DllImport("user32")]
			public static extern uint GetRawInputData(
				IntPtr hrawInput,
				uint command,
				ref RawKeyboard data,
				ref uint size,
				int headerSize);
		}
		class Form1 : Form
		{
			protected override void OnLoad(EventArgs e)
			{
				try {
					KeyboardRawInput.RawInputDevice dev = new KeyboardRawInput.RawInputDevice();
					dev.Page = 1;
					dev.Usage = 6;
					dev.Flags = 0x00000100 /*RIDEV_INPUTSINK*/;
					dev.HWnd = this.Handle;
					bool result = KeyboardRawInput.RegisterRawInputDevices(new KeyboardRawInput.RawInputDevice[] { dev }, 1, Marshal.SizeOf(typeof(KeyboardRawInput.RawInputDevice)));
					if (!result)
						throw new Exception(string.Format("LastError: 0x{0:x}", Marshal.GetLastWin32Error()));
				} catch (Exception ex) {
					MessageBox.Show(ex.Message, "Error registering RawInput");
				}
	
				base.OnLoad(e);
			}
			protected override void WndProc(ref Message m)
			{
				if (m.Msg == 0xFF) {
					KeyboardRawInput.RawKeyboard keyboard = new KeyboardRawInput.RawKeyboard();
					uint size = (uint)Marshal.SizeOf(keyboard);
					uint result = KeyboardRawInput.GetRawInputData(m.LParam, 0x10000003, ref keyboard, ref size, 4 + 4 + IntPtr.Size * 2);
					if (result != uint.MaxValue) {
						string parse = string.Format("MakeCode: 0x{0:X}\r\nMessage: 0x{1:X}\r\nVKey: 0x{2:X}", keyboard.MakeCode, keyboard.Message, keyboard.VKey);
						MessageBox.Show(parse);
					}
				}
				base.WndProc(ref m);
			}
		}
	}
