    public bool IsUsed 
    {  
     get
     {   
       try{
         ClassA a = new ClassA();   
         Collection<ClassA> myCollection = a.FindObject("Id = 1","");
    
         if(..) // etc  
       } 
       catch { return false;}
     } 
    }
