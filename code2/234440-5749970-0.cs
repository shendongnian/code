    class Ftp
        {
    
            public struct FileStruct
            {
                public string Flags;
                public string Owner;
                public string Group;
                public bool IsDirectory;
                public DateTime CreateTime;
                public string Name;
            }
    
            public enum FileListStyle
            {
                UnixStyle,
                WindowsStyle,
                Unknown
            }
    
            private List<FileStruct> GetList(string datastring)
            {
                List<FileStruct> myListArray = new List<FileStruct>();
                string[] dataRecords = datastring.Split('\n');
                FileListStyle _directoryListStyle = GuessFileListStyle(dataRecords);
                foreach (string s in dataRecords)
                {
                    if (_directoryListStyle != FileListStyle.Unknown && s != "")
                    {
                        FileStruct f = new FileStruct();
                        f.Name = "..";
                        switch (_directoryListStyle)
                        {
                            case FileListStyle.UnixStyle:
                                f = ParseFileStructFromUnixStyleRecord(s);
                                break;
                            case FileListStyle.WindowsStyle:
                                f = ParseFileStructFromWindowsStyleRecord(s);
                                break;
                        }
                        if (!(f.Name == "." || f.Name == ".."))
                        {
                            myListArray.Add(f);
                        }
                    }
                }
    
                return myListArray; ;
            }
    
            private FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
            {
                ///Assuming the record style as 
                /// 02-03-11  07:46PM       <DIR>          Append
                FileStruct f = new FileStruct();
                string processstr = Record.Trim();
                string dateStr = processstr.Substring(0, 8);
                processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
                string timeStr = processstr.Substring(0, 7);
                processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
                f.CreateTime = DateTime.Parse(dateStr + " " + timeStr);
                if (processstr.Substring(0, 5) == "<DIR>")
                {
                    f.IsDirectory = true;
                    processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
                }
                else
                {
                    string[] strs = processstr.Split(new char[] { ' ' });
                    processstr = strs[1].Trim();
                    f.IsDirectory = false;
                }
                f.Name = processstr;  //Rest is name   
                return f;
            }
    
    
            public FileListStyle GuessFileListStyle(string[] recordList)
            {
                foreach (string s in recordList)
                {
                    if (s.Length > 10 && Regex.IsMatch(s.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                    {
                        return FileListStyle.UnixStyle;
                    }
    
                    if (s.Length > 8 && Regex.IsMatch(s.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                    {
                        return FileListStyle.WindowsStyle;
                    }
                }
                return FileListStyle.Unknown;
            }
    
            private FileStruct ParseFileStructFromUnixStyleRecord(string record)
            {
                ///Assuming record style as
                /// dr-xr-xr-x   1 owner    group               0 Feb 25  2011 bussys
                FileStruct f = new FileStruct();
                string processstr = record.Trim();
    
                f.Flags = processstr.Substring(0, 9);
                f.IsDirectory = (f.Flags[0] == 'd');
    
                processstr = (processstr.Substring(11)).Trim();
    
                _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //skip one part
    
                f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
                f.Group = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
    
                _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //skip one part
    
                DateTime createTime = DateTime.Now;
    
                var dateString = _cutSubstringFromStringWithTrim(ref processstr, ' ', 8);
                DateTime.TryParse(dateString, out createTime);
    
                f.CreateTime = createTime;
                f.Name = processstr;   //Rest of the part is name
                return f;
            }
    
            private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
            {
                int pos1 = s.IndexOf(c, startIndex);
                string retString = s.Substring(0, pos1);
    
                s = (s.Substring(pos1)).Trim();
    
                return retString;
            }
    
            public List<FileStruct> GetDirectoryInformation(string ftpUri, NetworkCredential networkCredential)
            {
                List<FileStruct> directoryInfo = new List<FileStruct>();
                try
                {
                    FtpWebRequest ftpClientRequest = WebRequest.Create(ftpUri) as FtpWebRequest;
                    ftpClientRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    ftpClientRequest.Proxy = null;
                    ftpClientRequest.Credentials = networkCredential;
    
                    FtpWebResponse response = ftpClientRequest.GetResponse() as FtpWebResponse;
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.ASCII);
                    string datastring = sr.ReadToEnd();
                    response.Close();
                    
                    directoryInfo = GetList(datastring);
    
                    return directoryInfo;
                }
                catch (Exception e)
                {
                    return directoryInfo;
                }
            }
        }
