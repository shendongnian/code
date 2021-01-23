    object ob = ...
    object[] ar =..
    
    for (int i = 0; i < ar.Length; i++)
    {
        ob.GetType().GetProperty("Column" + i).SetValue(ob, ar[i], null);
    }
