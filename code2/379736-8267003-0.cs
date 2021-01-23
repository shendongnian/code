    using N; 
    namespace N2 {     
        class A : AI     
        {         
              
             BI Property1 
             { 
                  get 
                  { 
                       return new B(){Property1 = 5,Property2=100 };
                  } 
             }     
        } 
        
        class B : BI
        {
             int Property1 {get;set;}
             int Property2 {get;set;}
        }
    } 
