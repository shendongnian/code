    public class FFMpegWrapper
    {
        //path to ffmpeg (I HATE!!! MS special folders)
        string ffPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ffmpeg.exe";
	//outputLines receives each line of output, only if they are not zero length
        List<string> outputLines = new List<string>();
	//In GetVideoDuration I only want the one line of output and in text form.
	//To get the whole output just remove the filter I use (my search for 'Duration') and either return the List<>
	//Or joint the strings from List<> (you could have used StringBuilder, but I find a List<> handier.
        public string GetVideoDuration(FileInfo fi)
        {
            outputLines.Clear();
	//I only use the information flag in this function
            string strCommand = string.Concat(" -i \"", fi.FullName, "\"");
	//Point ffPath to my ffmpeg
            string ffPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ffmpeg.exe";
            Process processFfmpeg = new Process();
            processFfmpeg.StartInfo.Arguments = strCommand;
            processFfmpeg.StartInfo.FileName = ffPath;
	
	//I have to say that I struggled for a while with the order that I setup the process.
	//But this order below I know to work
            processFfmpeg.StartInfo.UseShellExecute = false;
            processFfmpeg.StartInfo.RedirectStandardOutput = true;
            processFfmpeg.StartInfo.RedirectStandardError = true;
            processFfmpeg.StartInfo.CreateNoWindow = true;
            processFfmpeg.ErrorDataReceived += processFfmpeg_OutData;
            processFfmpeg.OutputDataReceived += processFfmpeg_OutData;
            processFfmpeg.EnableRaisingEvents = true;
            processFfmpeg.Start();
            processFfmpeg.BeginOutputReadLine();
            processFfmpeg.BeginErrorReadLine();
            processFfmpeg.WaitForExit();
	//I filter the lines because I only want 'Duration' this time
            string oStr = "";
            foreach (string str in outputLines)
            {
                if (str.Contains("Duration"))
                {
                    oStr = str;
                }
            }
	//return a single string with the duration line
            return oStr;
        }
        private void processFfmpeg_OutData(object sender, DataReceivedEventArgs e)
        {
	//The data we want is in e.Data, you must be careful of null strings
            string strMessage = e.Data;
            if outputLines != null && strMessage != null && strMessage.Length > 0)
            {
                outputLines.Add(string.Concat( strMessage,"\n"));
		//Try a Console output here to see all of the output. Particularly
		//useful when you are examining the packets and working out timeframes
		//Console.WriteLine(strMessage);
            }
        } 
    }
}
