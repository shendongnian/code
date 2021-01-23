    public static bool operator == ( Effect a, Effect b )     
     {  
         return a!= null && b != null && a.TypeID.Equals (b.TypeID);    
     }  
     public static bool operator != ( Effect a, Effect b )
     {         
         return !(a == b );     
     }      
     public bool Equals ( Effect effect )     
     {         
        return this == effect );     
     }      
     public override bool Equals ( object obj )     
     {   
        return obj is effect && this == effect); 
     } 
 
  
