    IList<MyObject> list = new List<MyObject>( my_enumerable );
    Random rnd = new Random();
    for (int i = 0; i < list.Count; ++i)
    {
        int j = rnd.Next() % list.Count;
        MyObject tmp = list[i];
        list[i] = list[j];
        list[j] = tmp;
    }
    my_enumerable = list;
