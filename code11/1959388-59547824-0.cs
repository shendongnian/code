    {
        string path = @"textasd.txt";
        string ro = @"nums.dat";
        StreamWriter sw = new StreamWriter(path);
        StreamReader sr = new StreamReader(ro);
        int length = 0,c;
        char[] field= new char[10];
        var numbersProcessed = 0;  //----> this is new
        while ((c = sr.Read()) != -1)
        {
            if (char.IsDigit((char)c))
            {
                field[length] = (char)c;
                length++;
            }
            else
            {
                if(length >= 5)
                {
                    //---> new code starts
                    numbersProcessed++;
                    sw.Write(field, 0, length);
                    if (numbersProcessed % 10 == 0)
                    {
                         sw.WriteLine();
                    }
                    //---> new code ends
                }
                length = 0;
            }
        }
        sr.Close();
        sw.Close();
    }
