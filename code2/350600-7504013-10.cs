    unsafe public void Foo(int* x) // *x is an alias to a variable of type int.
    {
        int* y = x; // *y is now an alias to the same variable that *x aliases
        *y = 7; // changing *y now changes *x, and whatever *x 
                // aliases, because those are all the same variable
    }
