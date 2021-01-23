    class SerializablePrimative<T> : ISerializable {
       private T val = default();
       
       private SerializablePrimative(T newVal){
           val = newVal;
       }
    
       public static boolean IsSupported(Object o){
           if (o == null){
              return false;
           }else{
              return IsSupported(o.GetType());
           }
       }
    
       public static boolean IsSupported(Type t){
           if (// you want to support* ...)
           {
              return true;
           }
           else
           { 
             return false; 
           }
       }
    
       public static SerializablePrimative GetSerializable(Object o){
           if (IsSupported(o)){
                return //Intstatiate via Reflection **
           }else {
                return null;
           }
       }
    }
  
