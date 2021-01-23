    A                             //non generic, bound
    A<U, V>                       //generic,     bound,  open,   constructed
    A<int, V>                     //generic,     bound,  open,   constructed
    A<int, int>	                  //generic,     bound,  closed, constructed
    A<,> (used like typeof(A<,>)) //generic,     unbound 
