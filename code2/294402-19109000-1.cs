        public DataTable getFileListFTP(string serverIP,string userID,string Password)
        {
            DataTable dt = new DataTable();
            string[] fileListArr;
            string fileName = string.Empty;
            long fileSize = 0;
           // DateTime creationDate;
            string creationDate;
           
            FtpWebRequest Request = (FtpWebRequest)WebRequest.Create(serverIP);
            Request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            Request.Credentials = new NetworkCredential(userID,Password);
            FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();
            Stream ResponseStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(ResponseStream);
            dt.Columns.Add("FileName", typeof(String));
            dt.Columns.Add("FileSize", typeof(String));
            dt.Columns.Add("CreationDate", typeof(DateTime));
            //CultureInfo c = new CultureInfo("ES-ES");
            while (!Reader.EndOfStream)//Read file name   
            {
                fileListArr = Convert.ToString(Reader.ReadLine()).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                fileSize = long.Parse(fileListArr[4]);
                creationDate = fileListArr[6] + " " + fileListArr[5] + " " + fileListArr[7];
                //creationDate =Convert.ToDateTime(fileListArr[6] + " " + fileListArr[5] + " " + fileListArr[7], c).ToString("dd/MMM/yyyy", DateTimeFormatInfo.InvariantInfo);
                fileName = Convert.ToString(fileListArr[8]);
                DataRow drow = dt.NewRow();
                drow["FileName"] = fileName;
                drow["FileSize"] = fileName;
                drow["CreationDate"] = creationDate;
                dt.Rows.Add(drow);
            }
            Response.Close();
            ResponseStream.Close();
            Reader.Close();
            return dt;
        }
