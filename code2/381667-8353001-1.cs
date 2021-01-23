    string buffString = System.Text.ASCIIEncoding.ASCII.GetString(buff);
    using (Stream stm = req.GetRequestStream())
    {
        bool stmIsReadable = stm.CanRead;  //false, stream is not readable, how to get
                                           //around this?
                                           //solution: read Byte Array into a String,
                                           //modify <wsa:to>, write String back into a
                                           //Buffer, write Buffer to Stream
        buffString = buffString.Replace("http://localhost/WS/Service.asmx", WSaddress);
        //write modded string to buff
        buff = System.Text.UTF8Encoding.UTF8.GetBytes(buffString);
        stm.Write(buff, 0, (int)buff.Length);
    }
