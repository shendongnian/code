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
           Properties[i] = new sProperties(0);*/
       FeedMode = 1;
   }
};
And used the "Attemp1" code.
Now another question: what if I want the opposite? I want to make sure it certainly made the changes (since tested the method I need and still dont get the right result), so I'd use this one:
BOOL GetParameters( DWORD ID, DevParam *dParam )
In C# should look like:
[DllImport(path, EntryPoint = "?GetParameters@@YGHKU_DevParam@@@Z")]
public static extern bool GetParameters(int ID, ?????);
So what should I use? IntPtr? ref DevParam? do I need to Marshal again? And how to do that?
Thanks in advance :)
