    Action<string> commonHandler = (parameter) => 
       { 
             // handler code here 
       };
    class MyWindiow
    {
    
       public MyWindiow(Action<string> handler)
       { 
             // store to local and assign to button click
             // button.CLick += (o, e) => { handler(parameterToBepassed); }
       }
    }
