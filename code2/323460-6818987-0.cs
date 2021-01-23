    public class ConvertHandler : IHttpHandler
    {
        #region IHttpHandler Members
        bool IHttpHandler.IsReusable
        {
            get { return false; }
        }
        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            var jobID = Guid.NewGuid();
            // retrieve the posted csv file
            var csvFile = context.Request.Files["csv"]; 
            // save the file to disk so the CMD line util can access it
            var filePath = Path.Combine("csv", String.Format("{0:n}.csv", jobID));
            csvFile.SaveAs(filePath);
            var psi = new ProcessStartInfo("mycsvutil.exe", String.Format("-file {0}", filePath))
            {
                WorkingDirectory = Environment.CurrentDirectory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
                
            };
            using (var process = new Process { StartInfo = psi })
            {
                // delegate for writing the process output to the response output
                Action<Object, DataReceivedEventArgs> dataReceived = ((sender, e) =>
                {
                    context.Response.Write(e.Data);
                    context.Response.Write(Environment.NewLine);
                    context.Response.Flush();
                });
                process.OutputDataReceived += new DataReceivedEventHandler(dataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(dataReceived);
                // use text/plain so line breaks and any other whitespace formatting is preserved
                context.Response.ContentType = "text/plain";
                // start the process and start reading the standard and error outputs
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                // wait for the process to exit
                process.WaitForExit();
            }
        }
        #endregion
    }
