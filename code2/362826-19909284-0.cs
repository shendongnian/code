        Hashtable ht = new Hashtable();
        foreach (string s in inputStringArray)
        {
            if (!ht.Contains(s))
            {
                ht.Add(s, 1);
            }
            else
            {
                ht[s] = (int)ht[s] + 1;
            }
        }
