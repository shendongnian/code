     public static bool operator == ( Effect a, Effect b )     
     {  
         return a is Effect && b is Effect && a.TypeID.Equals (b.TypeID);    
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
        return obj is Effect && this == obj); 
     } 
