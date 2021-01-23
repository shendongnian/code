    using System.Runtime.InteropServices;
    ...
    public class MyClass
    {
        #region PInvokes
        [DllImport("Your.dll")]
        static public extern int Move(int val);
    ....
