        private void WritePDF(string HTML)
        {
            string inFileName,
                    outFileName,
                    tempPath;
            Process p;
            System.IO.StreamWriter stdin;
            ProcessStartInfo psi = new ProcessStartInfo();
            tempPath = Request.PhysicalApplicationPath + "temp\\";
            inFileName = Session.SessionID + ".htm";
            outFileName = Session.SessionID + ".pdf";
            // run the conversion utility
            psi.UseShellExecute = false;
            psi.FileName = "c:\\Program Files (x86)\\wkhtmltopdf\\wkhtmltopdf.exe";
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            // note that we tell wkhtmltopdf to be quiet and not run scripts
            // NOTE: I couldn't figure out a way to get both stdin and stdout redirected so we have to write to a file and then clean up afterwards
            psi.Arguments = "-q -n - " + tempPath + outFileName;
            p = Process.Start(psi);
            try
            {
                stdin = p.StandardInput;
                stdin.AutoFlush = true;
                stdin.Write(HTML);
                stdin.Close();
                if (p.WaitForExit(15000))
                {
                    // NOTE: the application hangs when we use WriteFile (due to the Delete below?); this works
                    Response.BinaryWrite(System.IO.File.ReadAllBytes(tempPath + outFileName));
                    //Response.WriteFile(tempPath + outFileName);
                }
            }
            finally
            {
                p.Close();
                p.Dispose();
            }
            // delete the pdf
            System.IO.File.Delete(tempPath + outFileName);
        }
