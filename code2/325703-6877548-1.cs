    myHashTable.GetAs<string>("value1");
    myHashTable.GetAs<int>("value2");
    public static T GetAs<T>( this Hashtable ht, object key )
    {
        return (T)ht[key];
    }
