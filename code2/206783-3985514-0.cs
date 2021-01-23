        public  bool isOpenofficeInstalled()
        {
           
            //The registry key:
            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                bool flag = false;
                //Let's go through the registry keys and get the info we need:
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            //If the key has value, continue, if not, skip it:
                          //  if (((sk.GetValue("DisplayName")).ToString() == "OpenOffice.org 3.2"))
                            if((sk.GetValue("DisplayName")).ToString() == "OpenOffice.org 3.2")
                            {
                                flag = true;
                                ////install location ?
                                //if (sk.GetValue("InstallLocation") == null)
                                //    Software += sk.GetValue("DisplayName") + " - Install path not known\n"; //Nope, not here.
                                //else
                                //    Software += sk.GetValue("DisplayName") + " - " + sk.GetValue("InstallLocation") + "\n"; //Yes, here it is...
                            }
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }
                return flag;
            }
          
        }
