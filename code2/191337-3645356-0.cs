    ArrayList list = new ArrayList();
    list.Add("The");
    list.Add("Quick");
    list.Add("Brown");
    list.Add("Fox");
    list.Add("Jumps");
    ArrayList newList = new ArrayList();
    int index = 2;
    for (int i = index; i < list.Count; i++)
    {
        newList.Add(list[i]);
    }
    for (int i = 0; i < index; i++)
    {
        newList.Add(list[i]);
    }
    list = newList;
