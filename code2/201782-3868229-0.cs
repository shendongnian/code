    delegate void Bar(object t);
    void foo(Bar bar)
    {
        bar.Invoke("hello");
        bar.Invoke(42);
    }
    void BarMethod(object t)
    {
        if (t is int)
            // ...
        else if (t is string)
            // ...
    }
    foo(BarMethod);
