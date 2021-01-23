            StringBuilder result = new StringBuilder();
            FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("ftp://urserverip/");
            requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
            requestDir.Credentials = new NetworkCredential("username", "password");
            FtpWebResponse responseDir = (FtpWebResponse)requestDir.GetResponse();
            StreamReader readerDir  = new StreamReader(responseDir.GetResponseStream());
            string line = readerDir.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = readerDir.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                responseDir.Close(); 
                return result.ToString().Split('\n');
           }
