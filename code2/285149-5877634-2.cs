	using System;
	using System.Runtime.InteropServices;
	delegate uint BinaryOp(uint a, uint b);
	static class Program
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool VirtualProtect(
			IntPtr address, IntPtr size, uint protect, out uint oldProtect);
		static void Main()
		{
			if (IntPtr.Size != 4) { throw new Exception("32-bit system required."); }
			var bytes = new byte[] {
				0x8B, 0x44, 0x24, 0x04, 0x0F, 0xAF, 0x44, 0x24, 0x08, 0xC3
			};
			var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
			try
			{
				uint old;
				VirtualProtect(handle.AddrOfPinnedObject(),
					(IntPtr)bytes.Length, 0x40, out old);
				var action = (BinaryOp)Marshal.GetDelegateForFunctionPointer(
					handle.AddrOfPinnedObject(), typeof(BinaryOp));
				var temp = action(3, 2); //6!
			}
			finally { handle.Free(); }
		}
	}
