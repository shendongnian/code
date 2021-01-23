    Item item = null;
    foreach(var a in A)
    {
        foreach(var b in a.B)
        {
            if (b.foo == someCondition)
            {
                item = b.item;
                goto AfterLoop;
            }
        }
    }
    AfterLoop:
