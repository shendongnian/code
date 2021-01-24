     private void InstallVCredist()
        {
            string exe = @"path to exe\VC_redist.x86.exe"; //set path
            string stp = @"\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"; //set subkey
            using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(stp)) //recall registry
            {
                if (reg != null)
                {
                    foreach (string dname in reg.GetSubKeyNames()) //loop search
                    {
                        using (RegistryKey sreg = reg.OpenSubKey(dname))
                        {
                            if (sreg.GetValue("DisplayName").ToString() == "Microsoft Visual C++ 2015-2019 Redistributable (x86) - 14.23.27820") //set dispayname of version
                            {
                                vcredist = "1"; //it's mine control variable
                                break;
                            }
                        }
                    }
                }
            }
            if (vcredist == "0") //now testing if it was found 
            {
                Process vc = new Process();
                vc.StartInfo.FileName = exe;
                //silent install
                vc.StartInfo.Arguments = "/install /passive /norestart";
                vc.StartInfo.UseShellExecute = false;
                vc.StartInfo.CreateNoWindow = true;
                //silent install
                vc.Start(); 
                vc.WaitForExit(); //as he says ;)
            }
        }
 
