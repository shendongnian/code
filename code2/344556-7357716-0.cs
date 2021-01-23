    private bool CheckMultipleInstanceofApp()
            {
                bool check = false;
                Process[] prc = null;
                string ModName, ProcName;
                ModName = Process.GetCurrentProcess().MainModule.ModuleName;
                ProcName = System.IO.Path.GetFileNameWithoutExtension(ModName);
                prc = Process.GetProcessesByName(ProcName);
                if (prc.Length > 1)
                {
                    MessageBox.Show("There is an Instance of this Application running");
                    check = true;
                    System.Environment.Exit(0);
                }
                return check;
            }
