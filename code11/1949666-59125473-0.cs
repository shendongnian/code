    using Microsoft.Win32;
    SystemEvents.SessionSwitch += (s, e) =>
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                {
                    // Do what you want here as the system is locked
                }
                else
                {
                    Console.WriteLine("Unlocked by: {0}", Environment.UserName);
                }
            };
