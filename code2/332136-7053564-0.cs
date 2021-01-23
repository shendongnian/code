    public static void RunAsAdmin(string fileName)
            {
                Process p = new Process();
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = fileName;
                p.Start();
            }
