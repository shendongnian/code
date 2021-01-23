     [XmlRoot("ErrorLog")]
        public class ErrorLog
        {
            [XmlElement("MethodName")]
            public string MethodName { get; set; }
            [XmlElement("FileName")]
            public string FileName { get; set; }
            [XmlElement("LineNumber")]
            public int LineNumber { get; set; }
            [XmlElement("ErrorMesssage")]
            public string ErrorMesssage { get; set; }
            [XmlElement("UserID")]
            public int UserID { get; set; }
            [XmlElement("ErrCode")]
            public ErrorCodes ErrCode { get; set; }
            [XmlElement("Time")]
            public string Time { get; set; }
            public ErrorLog()
            { }
            public ErrorLog(string sMethodName, string sFileName, int nLineNumber, string sErrorMesssage, int sUserID, ErrorCodes oErrCode)
            {
                MethodName = sMethodName;
                FileName = sFileName;
                LineNumber = nLineNumber;
                ErrorMesssage = sErrorMesssage;
                UserID = sUserID;
                ErrCode = oErrCode;
                Time = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss.fff");
            }
        }
