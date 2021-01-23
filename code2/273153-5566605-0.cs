    string strFileHeader = string.Empty;
    StringBuilder strBatchHeader=new StringBuilder();
    StringBuilder strEntry=new StringBuilder();
    StringBuilder strBtchcntrl=new StringBuilder();
    string strFileCntrl = string.Empty;
    using (StreamReader srRead = new StreamReader(filePath))
        {
            while (srRead.Peek() >= 0)
            {
                strLine = srRead.ReadLine();
                if (strLine.StartsWith("1"))
                {
                    strFileHeader = strLine;
                }
                if (strLine.StartsWith("5"))
                {
                    
                    strBatchHeader.AppendLine(strLine);
                }
                if (strLine.StartsWith("6"))
                {
                    strEntry.AppendLine(strLine);
                }
                if (strLine.StartsWith("8"))
                {
                    strBtchcntrl.AppendLine(strLine);
                }
                if (strLine.StartsWith("9"))
                {
                    strFileCntrl = strLine;
                }
            }
     string strQuery = "insert into tblfiles(FName, FData,FileHeader,BatchHeader,Entry,BtchEntry,FileControl) values (@_FName,@_FData,@_FileHeader,@_BtchHeader,@_EntryDets,@_BtchCntrl,@_FileCntrl)";
            MySqlCommand cmd = new MySqlCommand(strQuery);
            cmd.Parameters.Add("@_FName", MySqlDbType.VarChar).Value = filename;
            cmd.Parameters.Add("@_FData", MySqlDbType.LongBlob).Value = bytes;
            cmd.Parameters.Add("@_FileHeader", MySqlDbType.LongBlob).Value = strFileHeader;
            cmd.Parameters.Add("@_BtchHeader", MySqlDbType.LongBlob).Value = strBatchHeader.ToString();
            cmd.Parameters.Add("@_EntryDets", MySqlDbType.LongBlob).Value = strEntry.ToString();
            cmd.Parameters.Add("@_BtchCntrl", MySqlDbType.LongBlob).Value = strBtchcntrl.ToString();
            cmd.Parameters.Add("@_FileCntrl", MySqlDbType.LongBlob).Value = strFileCntrl;
            InsertUpdateData(cmd);
