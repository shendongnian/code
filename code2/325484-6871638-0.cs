    public  int CountProperty (int whichProperty) 
        {
            get
            {
                int count = 0;
                foreach (var row in Data)
                {
                    if( whichProperty = 1)
                        count = count + row.Property1;
                    if( whichProperty = 2)
                        count = count + row.Property2;
                }
                return count ;
            }
        }
