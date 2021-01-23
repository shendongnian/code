    List<string> Getlist()
    {
        List<string> mylist = new List<string>();
        for (bool successFlag = true; !successFlag; )
        {
            for (int i = 0; i < n; i++)
            {
                var CDF = GetCDF(); // IEnumerable
                if (!CDF.Any())
                {
                    fail++;
                    successFlag = false;
                    break;
                }
                string item = GetNext(CDF);
                mylist.Add(item);
            }
        }
        return mylist;
    }
