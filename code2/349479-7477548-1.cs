    myclass a = new myclass();
    a.integer = 1;
    myclass b = new myclass();
    b.integer = 2;
    var c = a; //Keep the old a around
    a = b;
    //here I need code to disconnect them
    a = c; //Restore it.
    a.integer = 1;
    Text = b.integer.ToString();
    //I need b.integer to still be = 2
