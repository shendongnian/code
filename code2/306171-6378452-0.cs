    class Test
        {
            public string ReadFromDb()
            {
                //Do your db work here
                return "";
            }
    
            public bool GetDefaultValue(ref int t1)
            {
                t1 = Int32.Parse(ReadFromDb());
                return true;
            }
    
            public bool GetDefaultValue(ref double t1)
            {
                t1 = Double.Parse( ReadFromDb() );
                return true;
            }
    
            public bool GetDefaultValue(ref string t1)
            {
                t1 = ReadFromDb();
                return true;
            }
        }
