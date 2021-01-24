    // Here we are creating anonymous functions with lambdas,
    // every time we create different object.
    Action d1 = () => Console.WriteLine("");
    Action d2 = () => Console.WriteLine("");
    d1==d2;
    // false
    // Here we use already defined method, one object represenitng the method.
    d1 = Console.WriteLine;
    d2 = Console.WriteLine;
    d1 == d2;
    // true
