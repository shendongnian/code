    using (ITransaction transaction = SessionInstance.BeginTransaction())
    {
        foreach (Family fam in person.Families)
        {
            if (fam.Name == "Jaun")
            {
                fam.Code = 100;
            }
        }
       
        transaction.Commit();
    }
