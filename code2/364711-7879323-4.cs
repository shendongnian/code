        string str = "021500010000146DE6D800000000000000003801030E9738";
        List<byte> myBytes = new List<byte>();
        try
        {
            while (!string.IsNullOrEmpty(str))
            {
                myBytes.Add(Convert.ToByte(str.Substring(0, 2), 16));
                str = str.Substring(2);
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
