    class Foo {
        public int? Bar {get;set;}
    }
    ...
    Type type = typeof(Foo); // usually indirectly
    foreach(var prop in type.GetProperties()) {
         Type propType = prop.PropertyType,
              nullType = Nullable.GetUnderlyingType(propType);
         if(nullType != null) {
             // special code for handling Nullable<T> properties;
             // note nullType now holds the T
         } else {
             // code for handling other properties
         }
    }
