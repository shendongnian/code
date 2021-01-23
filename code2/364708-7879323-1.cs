        string str = "021500010000146DE6D800000000000000003801030E9738";
        string temp = "";
        int num = 0;
        List<byte> myBytes = new List<byte>();
        try
        {
            while (!string.IsNullOrEmpty(str))
            {
                temp = str.Substring(0, 2);
                str = str.Substring(2);
                num = Convert.ToInt32(temp, 16);
                myBytes.Add(Convert.ToByte(num));
            }
        }
        catch (FormatException fe)
        {
            //handle error
        }
        for(int i = 0; i < myBytes.Count; i++)
        {
            Response.Write(myBytes[i].ToString() + "<br/>");
        }
