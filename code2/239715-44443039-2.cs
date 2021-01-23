    // This is how to call it
    private void buttonLog_Click(object sender, EventArgs e)
    {
        c_Log.writeToFile(textBoxMessages.Text, "../../log.log", 1);
    }
 
    public static class c_Log
    {
        static int iMaxLogLength = 15000; // Probably should be bigger, say 200,000
        static int iTrimmedLogLength = -1000; // minimum of how much of the old log to leave
        static public void writeToFile(string strNewLogMessage, string strFile, int iLogLevel)
        {
            try
            {
                FileInfo fi = new FileInfo(strFile);
                Byte[] bytesSavedFromEndOfOldLog = null;
                if (fi.Length > iMaxLogLength) // if the log file length is already too long
                {
                    using (BinaryReader br = new BinaryReader(File.Open(strFile, FileMode.Open)))
                    {
                        // Seek to our required position of what you want saved.
                        br.BaseStream.Seek(iTrimmedLogLength, SeekOrigin.End);
                        // Read what you want to save and hang onto it.
                        bytesSavedFromEndOfOldLog = br.ReadBytes((-1 * iTrimmedLogLength));
                    }
                }
                byte[] newLine = System.Text.ASCIIEncoding.ASCII.GetBytes(Environment.NewLine);
                FileStream fs = null;
                // If the log file is less than the max length, just open it at the end to write there
                if (fi.Length < iMaxLogLength) 
                    fs = new FileStream(strFile, FileMode.Append, FileAccess.Write, FileShare.Read);
                else // If the log file is more than the max length, just open it empty
                    fs = new FileStream(strFile, FileMode.Create, FileAccess.Write, FileShare.Read);
                using (fs)
                {
                    // If you are trimming the file length, write what you saved. 
                    if (bytesSavedFromEndOfOldLog != null)
                    {
                        Byte[] lineBreak = Encoding.ASCII.GetBytes("### " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " *** *** *** Old Log Start Position *** *** *** *** ###");
                        fs.Write(newLine, 0, newLine.Length);
                        fs.Write(newLine, 0, newLine.Length);
                        fs.Write(lineBreak, 0, lineBreak.Length);
                        fs.Write(newLine, 0, newLine.Length);
                        fs.Write(bytesSavedFromEndOfOldLog, 0, bytesSavedFromEndOfOldLog.Length);
                        fs.Write(newLine, 0, newLine.Length);
                    }
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(strNewLogMessage);
                    // Append your last log message. 
                    fs.Write(sendBytes, 0, sendBytes.Length);
                    fs.Write(newLine, 0, newLine.Length);
                }
            }
            catch (Exception ex)
            {
                ; // Nothing to do...
                  //writeEvent("writeToFile() Failed to write to logfile : " + ex.Message + "...", 5);
            }
        }
    }
