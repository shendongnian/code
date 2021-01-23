    public void GetVideoInfo(string input)
        {
            //  set up the parameters for video info.
            string @params = string.Format("-i {0}", input);
            string output = Run(ffmpegProcess, @params);
            //get the video format
            re = new Regex("(\\d{2,3})x(\\d{2,3})");
            Match m = re.Match(output);
            if (m.Success)
            {
                int width = 0; int height = 0;
                int.TryParse(m.Groups[1].Value, out width);
                int.TryParse(m.Groups[2].Value, out height);
            }
        }
    private static string Run(string process/*ffmpegFile*/, string parameters)
        {
            if (!File.Exists(process))
                throw new Exception(string.Format("Cannot find {0}.", process));
            //  Create a process info.
            ProcessStartInfo oInfo = new ProcessStartInfo(process, parameters);
            //oInfo.UseShellExecute = false;
            //oInfo.CreateNoWindow = true;
            //oInfo.RedirectStandardOutput = true;
            //oInfo.RedirectStandardError = true;
            //  Create the output and streamreader to get the output.
            string output = null;
            //StreamReader outputStream = null;
            //  Try the process.
            //try
            //{
            //  Run the process.
            Process proc = System.Diagnostics.Process.Start(oInfo);
            proc.WaitForExit();
            //outputStream = proc.StandardError;
            //output = outputStream.ReadToEnd();    
            proc.Close();
            //}
            //catch( Exception ex )
            //{
            //    output = ex.Message;
            //}
            //finally
            //{
            //    //  Close out the streamreader.
            //    if( outputStream != null )
            //        outputStream.Close();
            //}
            return output;
        }
