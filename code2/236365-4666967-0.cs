    void Put(params string[] nameEqualValues)
    {
        foreach (string nameEqualValue in nameEqualValues)
        {
            int iEquals = nameEqualValue.IndexOf('=');
            if (iEquals < 0)
            {
                throw new ApplicationException(...);
            }
            string name = nameEqualValue.Substring(0, iEquals);
            string val = nameEqualValue.Substring(iEquals + 1);
    
            this.PutNameValue(name, val);
        }
    }
