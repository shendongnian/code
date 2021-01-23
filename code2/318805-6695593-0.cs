    Func<object> method;
    var choice = "D";
    if(choice=="D")
    {
        method = () => (object)D;
    }
    else if(choice=="B")
    {
        method = () => (object)B;
    }
    else if(choice=="S")
    {
        method = () => (object)S;
    }
    else return;
    DoSomething(method); // call another method using the method as a delegate.
    // or instead of calling another method, I want to do:
    for(int i = 0; i < 20; i++){
       SomeArray[i] = method();
    }
