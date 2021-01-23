    MyObject begin = GetFirst();
    while (begin != null)
    {
        MyObject next;
        using (begin)
        {
            next = begin.Next();
            // do something with begin
        }
        begin = next;
    }
