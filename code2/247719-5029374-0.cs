                foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.StartsWith("openvpn"))
                {
                    p.Kill();
                    Console.WriteLine("Killed Process");
                    break;
                }
            }
