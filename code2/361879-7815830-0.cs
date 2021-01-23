    public int CompareTime(string t1, string t2)
            {
    
                int i = -1;
    
                int hr1 = Convert.ToInt32(t1.Split(':')[0]);
                int hr2 = Convert.ToInt32(t2.Split(':')[0]);
    
                int min1 = Convert.ToInt32(t1.Split(':')[1]);
                int min2 = Convert.ToInt32(t2.Split(':')[1]);
    
                if (hr2 == hr1)
                {
                    if (min2 >= min1)
                    {
                        i = 1;
                    }
                }
    
                if (hr2 > hr1)
                {
                    i = 1;
                }
    
                return i;
            }
