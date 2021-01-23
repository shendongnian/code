    public byte[] WKHtmlToPdf(string url_input)
        {
            try
            {
                var fileName = " - ";
                var wkhtmlDir = ConfigurationSettings.AppSettings["wkhtmlDir"];
                var wkhtml = ConfigurationSettings.AppSettings["wkhtml"];
                var p = new Process();
                string url = Request.Url.GetLeftPart(UriPartial.Authority) + @"/application/" + url_input;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = wkhtml;
                p.StartInfo.WorkingDirectory = wkhtmlDir;
                string switches = "";
                switches += "--print-media-type ";
                switches += "--margin-top 10mm --margin-bottom 10mm --margin-right 10mm --margin-left 10mm ";
                switches += "--page-size Letter ";
                p.StartInfo.Arguments = switches + " " + url + " " + fileName;
                p.Start();
                //read output
                byte[] buffer = new byte[32768];
                byte[] file;
                using (var ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                        {
                            break;
                        }
                        ms.Write(buffer, 0, read);
                    }
                    file = ms.ToArray();
                }
                // wait or exit
                p.WaitForExit(60000);
                // read the exit code, close process
                int returnCode = p.ExitCode;
                p.Close();
                return returnCode == 0 ? file : null;
            }
            catch (Exception ex)
            {
               // set your exceptions here
                return null;
            }
        }
