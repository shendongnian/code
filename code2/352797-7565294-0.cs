        string b = listA.Find(delegate(string a) { return listB.Contains(a); });
        if (string.IsNullOrEmpty(b))
        {
            //disable control
        }
        else
        {
            //enable control
        }
