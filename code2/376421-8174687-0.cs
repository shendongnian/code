    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.IO;
    public delegate bool InteropCallback(int handle, System.IntPtr payload);
    public class InteropApp
    {
        [DllImport("user32.dll")]
        public static extern bool EnumWindows(InteropCallback cb, System.IntPtr payload);
        public static void Main()
        {
            var tw = System.Console.Out;
            var twhandle = GCHandle.Alloc(tw);
            InteropCallback cb = CallbackFunc;
            EnumWindows(cb, GCHandle.ToIntPtr(twhandle));
            twhandle.Free();
        }
        private static bool CallbackFunc(int handle, System.IntPtr payload)
        {
            var gch = GCHandle.FromIntPtr(payload);
            var tw = (TextWriter)gch.Target;
            tw.WriteLine(handle);
            return true;
        }
    }
