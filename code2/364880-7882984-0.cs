    ConcurrentQueue<MyClass> cq = new ConcurrentQueue<MyClass>();
    void GetStuff()
    {
        MyClass item;
        if(cq.TryDeqeue(out item))
        {
            //Work with item
        }
    }
