    IList<MyObject> list = new List<MyObject>( my_enumerable );
    Random rnd = new Random();
    for (int i = list.Count - 1; i > 0; --i)
    {
        int j = rnd.Next(i + 1);
        MyObject tmp = list[i];
        list[i] = list[j];
        list[j] = tmp;
    }
    my_enumerable = list;
