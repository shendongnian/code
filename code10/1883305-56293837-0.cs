    public void Change_adapter_status(bool _option, string _interface)
            {
                SecureString password = new SecureString();
                password.AppendChar('p');
                password.AppendChar('a');
                password.AppendChar('s');
                password.AppendChar('s');
                password.AppendChar('w');
                password.AppendChar('o');
                password.AppendChar('r');
                password.AppendChar('d');
    
                Process p = new Process();
                p.StartInfo.UserName = "Administrator";
                p.StartInfo.Domain = "domain";
                p.StartInfo.Password = password;
                p.StartInfo.FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = false;
    
                if (_option == true)
                {
                    p.StartInfo.Arguments = String.Format("netsh interface set interface „{0}“ enable", _interface);
                }
                else if (_option == false)
                {
                    p.StartInfo.Arguments = String.Format("netsh interface set interface „{0}“ disable", _interface);
                }
                p.Start();
                p.WaitForExit();
                Get_adapters(true);
            }
