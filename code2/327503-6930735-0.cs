    List<int> list1 = new List<int>();
    //Code to fill the list
    for(var n = 0; n < list.Count; i++)
    {
        if (list[n] % 5 == 0)
        {
            list1.Remove(list[n--]);
        }
    }
