    List<string> list = ...;
    List<string> uppercase = new List<string> ();
    for (int i = 0; i < list.Count; i++)
    {
        string name = list[i];
        uppercase.Add (name.ToUpper ());
    }
