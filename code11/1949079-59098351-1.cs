     public struct Parameter { 
         public Parameter( string name, object value) { … } 
         public string Name { get; private set; }
         public object Value { get; private set; }
     }
     abstract public class Element { 
        …
        abstract public bool TrySetParameters( params Parameter[] parameters); 
     }
