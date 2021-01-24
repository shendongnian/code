        // First, lets grab all of the processes that match the desired name
        var flashingProcesses = Process.GetProcesses().Where(p => p.ProcessName.ToLower() == "...")
            // Next, lets Select what we want from these processes
            .Select(process =>
            {
                using (process)
                {
                    using (ProcessModule module = process.MainModule)
                    {
                        var moduleHandle = GetModuleHandleEx(0x00000004, module.ModuleName, out var hModule);
                        var hHook = SetWindowsHookEx(HookType.WH_SHELL, (code, param, lParam) =>
                        {
                            //test
                            return IntPtr.Zero;
                        }, hModule, 0);
                        return hHook;
                    }
                }
            })
            // Finally, lets filter out the non-flashing proceses
            .Where(ptr => ptr != IntPtr.Zero);
        var count = flashingProcesses.Count();
        Console.WriteLine($"There are ${count} flashing processes");
