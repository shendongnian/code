        private string GetPUID(string fileName)
        {
            
            Process p;
            ProcessStartInfo si;
            string outRow;
            string puidReturned;
            string gendPuidPath = @"C:\Program Files\genpuid\genpuid.exe";
            string gendPuidKey = "your key here";
            System.Text.RegularExpressions.Regex puidRex = new System.Text.RegularExpressions.Regex( @"puid: (\S+)" ); // sample:  puid: 3c62e009-ec93-1c0f-e078-8829e885df67
            System.Text.RegularExpressions.Match m;
            if (File.Exists(gendPuidPath))
            {
                try
                {
                    si = new ProcessStartInfo(gendPuidPath, gendPuidKey + " \"" + fileName + "\"");
                    si.RedirectStandardOutput = true;
                    si.UseShellExecute = false;
                    p = new Process();
                    p.StartInfo = si;
                    p.Start();
                    puidReturned = "";
                    while ((outRow = p.StandardOutput.ReadLine()) != null)
                    {
                        m = puidRex.Match(outRow);
                        if (m.Success)
                            puidReturned = m.Groups[1].Value;
                        Debug.WriteLine(outRow);
                    }
                    p.WaitForExit();
                    p.Close();
                    return puidReturned;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                    throw new Exception("Unexpexted Error obtaining PUID for file: " + fileName, ex);
                }
            }
            else
            {
                Debug.WriteLine("genpuid.exe not found");
                return "";
            }
        }
