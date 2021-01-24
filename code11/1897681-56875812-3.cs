    for (int i = 0; i < list1.Count; i++) {
        object item = list1[i];
        switch (item)
        {
            case int x:
                // do some thing with x
                break;
            case string s:
                // do some thing with s
                break;
            case IList list:
                // do some thing with list
                break;
            ....
        }
    }
