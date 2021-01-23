    private delegate int MyDelegate();
    private MyDelegate method;
        
        
        var choice = "D";
        
        if(choice=="D")
        {
            method = D;
        }
        else if(choice=="B")
        {
            method = B;
        }
        else if(choice=="S")
        {
            method = S;
        }
        else return;
        
        DoSomething(method); 
