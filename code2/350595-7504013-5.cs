    public void Foo(ref int x) // x is an alias to another variable of type int.
    {
        int y = x; // y is a copy of the contents of x
        y = 7; // The contents of y are no longer a copy of the contents of x
    }
