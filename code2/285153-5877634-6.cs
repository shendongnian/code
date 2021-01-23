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
			var bytes = IntPtr.Size == sizeof(int) //32-bit? It's slower BTW
				? Convert.FromBase64String("i0QkBA+vRCQIww==")
				: Convert.FromBase64String("D6/Ki8HD");
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
