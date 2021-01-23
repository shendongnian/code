    UserPropertyList = new List<string>();
    
    ActiveDirectorySchema currSchema = ActiveDirectorySchema.GetCurrentSchema();
    
    ICollection Collection = currSchema.FindAllProperties();
    
    IEnumerator Enumerator = Collection.GetEnumerator();
    
    while (Enumerator.MoveNext())
    {
       UserPropertyList.Add(Enumerator.Current.ToString());
    }
