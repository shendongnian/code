    bool b=true; 
            decimal dec; 
            string CurLine = "";        
            CurLine = sr.ReadLine();
            string[] splitArray = CurLine.Split(new Char[] { '=' });
            splitArray[1] = splitArray[1].Trim();
            if (splitArray[1].Equals("Y") || splitArray[1].Equals("y")) b = true; else b = false;
            CurChADetails.DesignedProfileRawDataDsty1.Commen.IsPad = b;
