    namespace NetComClassLibrary3
    {
        // technically, we don't *have to* define an interface, we could do everything using dynamic stuff
        // but it's more practical so we can reference this .NET dll from our client
        [ComVisible(true)]
        [Guid("31dd1263-0002-4071-aa4a-d226a55116bd")]
        public interface IMyClass
        {
            event OnMyEventDelegate OnMyEvent;
            object MyMethod();
        }
        // same remark than above.
        // This *must* match the OnMyEvent signature below
        [ComVisible(true)]
        [Guid("31dd1263-0003-4071-aa4a-d226a55116bd")]
        public delegate void OnMyEventDelegate(string text);
        // this "event" interface is mandatory
        // note from the .NET perspective, no one seems to implement it
        // but it's referenced with the ComSourceInterfaces attribute on our COM server (below)
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("31dd1263-0000-4071-aa4a-d226a55116bd")]
        public interface IMyEvents
        {
            // dispids are mandatory here otherwise you'll get a DISP_E_UNKNOWNNAME error
            [DispId(1)]
            void OnMyEvent(string text);
        }
        [ComVisible(true)]
        [ComSourceInterfaces(typeof(IMyEvents))]
        [Guid("31dd1263-0001-4071-aa4a-d226a55116bd")]
        public class MyClass : IMyClass
        {
            public event OnMyEventDelegate OnMyEvent;
            public object MyMethod()
            {
                // we use the current running process to test out stuff
                // this should be Windows' default surrogate: dllhost.exe
                var process = Process.GetCurrentProcess();
                var text = "MyMethod. Bitness: " + IntPtr.Size + " Pid: " + process.Id + " Name: " + process.ProcessName;
                Console.WriteLine(text); // should not be displayed when running under dllhost
                OnMyEvent?.Invoke("MyEvent. " + text);
                return text;
            }
        }
    }
