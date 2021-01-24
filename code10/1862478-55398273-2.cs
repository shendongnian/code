[StructLayout(LayoutKind.Sequential)]
public struct DevParam
{
   public bool Enable;
   public uint Font;
   public char Symbol;
   public ImParam Image1;
   public ImParam Image2;
   //public IntPtr Properties;
   [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
   public sProperties[] Properties;
   public uint FeedMode;
   public DeviceParameters(int n) //(IntPtr SnP)
   {
       Enable = true;
       Font = 0;
       Symbol = '?';
       Image1 = new ImParam(3);
       Image2 = new ImParam(3);
       //Properties = SnP;
       Properties = new sProperties[n];
        for(int i = 0; i < n; i++)
           Properties[i] = new sProperties(0);
       FeedMode = 1;
   }
};
And used the "Attemp1" code.
