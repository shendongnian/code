    class Foo 
    {    
       public string Foo {get; set;} 
       public string Bar {get; set;} 
       public bool IsValid {get ; set;}
       
       private void Validation()   
       {      
          if(foo == "")         
           IsValid = false;      
         if ...    
       }  
 
       public void Foo(string foo = string.Empty, string bar = string.Empty)
       {
          Foo = foo;
          Bar = bar;
          Validation();
       }
    } 
    .....
    var t = new Foo (Foo = "SomeString");
