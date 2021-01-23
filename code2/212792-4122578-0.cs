    using(StreamReader reader = new StreamReader(modifiedFile))
    {
        
        while(!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] split = line.Split(',');
            if(split[1]==barcode)
            {
                found = true;
                break;
            }
        }
    }
