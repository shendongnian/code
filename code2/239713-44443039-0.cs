    static int iMaxLogLength = 150000;
    static int iTrimmedLogLength = -10000;
    static public void writeToFile(string strMessage, string strFile, int iLogLevel)
    {
        try
        {
            FileInfo fi = new FileInfo(strFile);
            Byte[] bytesRead = null;
            if (fi.Length > iMaxLogLength)
            {
                using (BinaryReader br = new BinaryReader(File.Open(strFile, FileMode.Open)))
                {
                    // 3. Seek to our required position.
                    br.BaseStream.Seek(iTrimmedLogLength, SeekOrigin.End);
                    // 4. Read what you want.
                    bytesRead = br.ReadBytes((-1 * iTrimmedLogLength));
                }
            }
            byte[] newLine = System.Text.ASCIIEncoding.ASCII.GetBytes(Environment.NewLine);
            FileStream fs = null;
            if (fi.Length < iMaxLogLength)
                fs = new FileStream(strFile, FileMode.Append, FileAccess.Write, FileShare.Read);
            else
                fs = new FileStream(strFile, FileMode.Create, FileAccess.Write, FileShare.Read);
            using (fs)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(strMessage);
                fs.Write(sendBytes, 0, sendBytes.Length);
                fs.Write(newLine, 0, newLine.Length);
                if (bytesRead != null)
                {
                    Byte[] lineBreak = Encoding.ASCII.GetBytes("### " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " *** *** *** Old Log Start Position *** *** *** *** ###");
                    fs.Write(newLine, 0, newLine.Length);
                    fs.Write(newLine, 0, newLine.Length);
                    fs.Write(lineBreak, 0, lineBreak.Length);
                    fs.Write(newLine, 0, newLine.Length);
                    fs.Write(bytesRead, 0, bytesRead.Length);
                    fs.Write(newLine, 0, newLine.Length);
                }
            }
        }
        catch (Exception ex)
        {
            ; // Nothing to do...
            //writeEvent("writeToFile() Failed to write to logfile : " + ex.Message + "...", 5);
        }
    }
