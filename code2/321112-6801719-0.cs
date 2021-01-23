    static void Main(string[] args)
      {
         string strSystem = "MAPS";
         FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://" + strSystem +"//export/home/hinest/science/trans/fred.txt");
         req.Credentials = CGetCred.GetCred(strSystem);
         req.Method = WebRequestMethods.Ftp.UploadFile;
         FtpWebResponse resp = (FtpWebResponse)req.GetResponse();
         StreamWriter fileOut = new StreamWriter(req.GetRequestStream());
         StreamReader fileIn = new StreamReader(@"c:\science\"+strSystem+".txt");
         while (!fileIn.EndOfStream)
         {
            fileOut.WriteLine(fileIn.ReadLine());
         }
         fileIn.Close();
         fileOut.Close();
         resp.Close();
      }
