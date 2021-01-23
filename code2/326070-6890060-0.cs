        newZipCodesList.Sort(new Test());
        
    
       public class Test : IComparer<string>
        {
    
            public int Compare(string x, string y)
            {
                if(Convert.ToInt32(x) > Convert.ToInt32(y))
                    return 1;
                else if (Convert.ToInt32(x) < Convert.ToInt32(y))
                    return -1;
                else
                    return 0;
            }
        }
