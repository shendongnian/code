    void receiveData(NetworkStream ns)
    {
        using (MemoryStream mems = new MemoryStream())
        {
            int formatByte = ns.ReadByte(); // Read the data type header
            
            ns.CopyTo(mems);
            mems.Position = 0;
            
            switch (formatByte)
            {
                case (int)'a': // Type A
                    // Read type 'a' from "mems"
                    // ...
                    break;
                
                case (int)'b': // Type B
                    // Read type 'b' from "mems"
                    // ...
                    break;
                
                default:
                    // In case you want to point out the unrecognized type
                    break;
            }
        }
    }
