...
using System.Runtime.InteropServices;
[StructLayout(LayoutKind.Sequential)]
public struct Type1
{
   [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
   public char[] FirstName;
   [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
   public char[] LasteName;
   [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] 
   public char[] Address;
   ...
}
