        var path = new ManagementPath();
        path.NamespacePath = "\\ROOT\\CIMV2\\Security\\MicrosoftVolumeEncryption"; path.ClassName = "Win32_EncryptableVolume";
        var scope = new ManagementScope(path, new ConnectionOptions() { Impersonation = ImpersonationLevel.Impersonate });
        var management = new ManagementClass(scope, path, new ObjectGetOptions());
        foreach (ManagementObject vol in management.GetInstances())
        {
            Console.WriteLine("----" + vol["DriveLetter"]);
            switch ((uint)vol["ProtectionStatus"])
            {
                case 0:
                    Console.WriteLine("not protected by bitlocker");
                    break;
                case 1:
                    Console.WriteLine("unlocked");
                    break;
                case 2:
                    Console.WriteLine("locked");
                    break;
            }
            if ((uint)vol["ProtectionStatus"] == 2)
            {
                Console.WriteLine("unlock this driver ...");
                vol.InvokeMethod("UnlockWithPassphrase", new object[] { "here your pwd" });
                Console.WriteLine("unlock done.");
            }
        }
