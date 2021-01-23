       public void MyMethod() {...}
       public void AnotherMethod { MyMethod(); };
    
       ...
       
       Action one = () => MyMethod();
       Action two = () => AnotherMethod();
    
       var equal = one == two; // false
 
