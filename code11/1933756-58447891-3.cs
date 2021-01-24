    public sealed class MinHook : IDisposable
    {
        private static readonly Lazy<IntPtr> _module = new Lazy<IntPtr>(HookNativeProcs, true);
        public static string NativeDllPath { get; private set; }
        private IntPtr _handle;
        public MinHook()
        {
            var hook = _module.Value;
            CheckError(_MH_Initialize());
        }
        public IntPtr CreateHook<T>(string libraryName, string procName, T detour)
        {
            if (libraryName == null)
                throw new ArgumentNullException(nameof(libraryName));
            if (procName == null)
                throw new ArgumentNullException(nameof(procName));
            var module = LoadLibrary(libraryName);
            if (module == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
            var address = GetProcAddress(module, procName);
            if (address == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
            var ptr = Marshal.GetFunctionPointerForDelegate<T>(detour);
            CheckError(_MH_CreateHook(address, ptr, out IntPtr original));
            return address;
        }
        public void EnableHook(IntPtr hook)
        {
            if (hook == IntPtr.Zero)
                throw new ArgumentException(null, nameof(hook));
            CheckError(_MH_EnableHook(hook));
        }
        public void DisableHook(IntPtr hook)
        {
            if (hook == IntPtr.Zero)
                throw new ArgumentException(null, nameof(hook));
            CheckError(_MH_DisableHook(hook));
        }
        public void RemoveHook(IntPtr hook)
        {
            if (hook == IntPtr.Zero)
                throw new ArgumentException(null, nameof(hook));
            CheckError(_MH_RemoveHook(hook));
        }
        public void Dispose()
        {
            var handle = Interlocked.Exchange(ref _handle, IntPtr.Zero);
            if (handle != IntPtr.Zero)
            {
                CheckError(_MH_Uninitialize());
            }
        }
        private Exception CheckError(MH_STATUS status, bool throwOnError = true)
        {
            if (status == MH_STATUS.MH_OK)
                return null;
            var ex = new Exception(status.ToString());
            if (throwOnError)
                throw ex;
            return ex;
        }
        // with this code, we support AnyCpu targets
        private static IEnumerable<string> PossibleNativePaths
        {
            get
            {
                string bd = AppDomain.CurrentDomain.BaseDirectory;
                string rsp = AppDomain.CurrentDomain.RelativeSearchPath;
                string bitness = IntPtr.Size == 8 ? "64" : "86";
                bool searchRsp = rsp != null && bd != rsp;
                // look for an env variable
                string env = GetEnvironmentVariable("MINHOOK_X" + bitness + "_DLL");
                if (env != null)
                {
                    // full path?
                    if (Path.IsPathRooted(env))
                    {
                        yield return env;
                    }
                    else
                    {
                        // relative path?
                        yield return Path.Combine(bd, env);
                        if (searchRsp)
                            yield return Path.Combine(rsp, env);
                    }
                }
                // look in appdomain path
                string name = "minhook.x" + bitness + ".dll";
                yield return Path.Combine(bd, name);
                if (searchRsp)
                    yield return Path.Combine(rsp, name);
                name = "minhook.dll";
                yield return Path.Combine(bd, name); // last resort, hoping the bitness's right, we do not recommend it
                if (searchRsp)
                    yield return Path.Combine(rsp, name);
            }
        }
        private static string GetEnvironmentVariable(string name)
        {
            try
            {
                string value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
                if (value != null)
                    return value;
                value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
                if (value != null)
                    return value;
                return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
            }
            catch
            {
                // probably an access denied, continue
                return null;
            }
        }
        private static IntPtr HookNativeProcs()
        {
            var path = PossibleNativePaths.FirstOrDefault(p => File.Exists(p));
            if (path == null)
                throw new Exception("Cannot determine native MinHook dll path. Process is running " + (IntPtr.Size == 8 ? "64" : "32") + "-bit.");
            NativeDllPath = path;
            var module = LoadLibrary(path);
            if (module == IntPtr.Zero)
                throw new Exception("Cannot load native MinHook dll from path '" + path + "'. Process is running " + (IntPtr.Size == 8 ? "64" : "32") + "-bit.", new Win32Exception(Marshal.GetLastWin32Error()));
            _MH_Initialize = LoadProc<MH_Initialize>(module);
            _MH_Uninitialize = LoadProc<MH_Uninitialize>(module);
            _MH_CreateHook = LoadProc<MH_CreateHook>(module);
            _MH_RemoveHook = LoadProc<MH_RemoveHook>(module);
            _MH_EnableHook = LoadProc<MH_EnableHook>(module);
            _MH_DisableHook = LoadProc<MH_DisableHook>(module);
            return module;
        }
        private static T LoadProc<T>(IntPtr module, string name = null)
        {
            if (name == null)
            {
                name = typeof(T).Name;
            }
            var address = GetProcAddress(module, name);
            if (address == IntPtr.Zero)
                throw new Exception("Cannot load library function '" + name + "' from '" + NativeDllPath + "'. Please make sure MinHook is the latest one.", new Win32Exception(Marshal.GetLastWin32Error()));
            return (T)(object)Marshal.GetDelegateForFunctionPointer(address, typeof(T));
        }
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate MH_STATUS MH_Initialize();
        private static MH_Initialize _MH_Initialize;
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate MH_STATUS MH_Uninitialize();
        private static MH_Uninitialize _MH_Uninitialize;
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate MH_STATUS MH_CreateHook(IntPtr pTarget, IntPtr pDetour, out IntPtr ppOriginal);
        private static MH_CreateHook _MH_CreateHook;
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate MH_STATUS MH_RemoveHook(IntPtr pTarget);
        private static MH_RemoveHook _MH_RemoveHook;
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate MH_STATUS MH_EnableHook(IntPtr pTarget);
        private static MH_EnableHook _MH_EnableHook;
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate MH_STATUS MH_DisableHook(IntPtr pTarget);
        private static MH_DisableHook _MH_DisableHook;
    }
    public enum MH_STATUS
    {
        // Unknown error. Should not be returned.
        MH_UNKNOWN = -1,
        // Successful.
        MH_OK = 0,
        // MinHook is already initialized.
        MH_ERROR_ALREADY_INITIALIZED,
        // MinHook is not initialized yet, or already uninitialized.
        MH_ERROR_NOT_INITIALIZED,
        // The hook for the specified target function is already created.
        MH_ERROR_ALREADY_CREATED,
        // The hook for the specified target function is not created yet.
        MH_ERROR_NOT_CREATED,
        // The hook for the specified target function is already enabled.
        MH_ERROR_ENABLED,
        // The hook for the specified target function is not enabled yet, or already
        // disabled.
        MH_ERROR_DISABLED,
        // The specified pointer is invalid. It points the address of non-allocated
        // and/or non-executable region.
        MH_ERROR_NOT_EXECUTABLE,
        // The specified target function cannot be hooked.
        MH_ERROR_UNSUPPORTED_FUNCTION,
        // Failed to allocate memory.
        MH_ERROR_MEMORY_ALLOC,
        // Failed to change the memory protection.
        MH_ERROR_MEMORY_PROTECT,
        // The specified module is not loaded.
        MH_ERROR_MODULE_NOT_FOUND,
        // The specified function is not found.
        MH_ERROR_FUNCTION_NOT_FOUND
    }
