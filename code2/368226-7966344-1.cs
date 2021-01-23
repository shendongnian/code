    foreach (Family fam in person.Families)
    {
        if (fam.Name == "Jaun")
        {
            fam.Code = 100;
        }
    }
    
    SessionInstance.Flush();
