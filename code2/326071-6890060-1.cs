       newZipCodesList.Sort(new Test());
            
       public class Test : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                //return 1 when first is greater than second
                if(Convert.ToInt32(x) > Convert.ToInt32(y))
                    return 1;
                //return -1 when first is less than second
                else if (Convert.ToInt32(x) < Convert.ToInt32(y))
                    return -1;
                //return 0 if they are equal
                else
                    return 0;
            }
        }
