    class A			            //non generic (I think that's enough)
    class A<T, U, V>		    //generic, open,   bound 
    class A<int, U, V>		    //generic, open,   bound, constructed 
    class A<int, int, V>	    //generic, open,   bound, constructed
    class A<int, int, int>	    //generic, closed, bound, constructed
    //adding one myself
    A<> (used like typeof(A<>)) //generic, unbound
