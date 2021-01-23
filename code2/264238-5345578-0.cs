        StreamWriter sw = new StreamWriter(@"c:\log.csv", true); 
        int iColCount = 8; 
        for (int i = 0; i < iColCount; i++)
        {           
            {
                sw.Write(i.ToString()); 
                sw.Write("\t"); 
            } 
        } 
        sw.Write("\r\n"); 
        sw.Flush(); 
        sw.Close();
