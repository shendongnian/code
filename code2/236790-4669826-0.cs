       public string ValueString { get; set; }      
       private Type ValueType { get; }      
       public T Value<T>  
       { 
           get {  return /*Something cast to a T */ ; }     
       }
  }
