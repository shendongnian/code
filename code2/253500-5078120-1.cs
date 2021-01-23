    class Example
    {
        OrderedLock inner = new OrderedLock("Inner");
        OrderedLock outer = new OrderedLock("Outer");
        
        Example()
        {
            outer.InnerLock = inner;
        }
    }
