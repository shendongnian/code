     public static class FieldTypeExtensions {
       public static Control CreateControl(this FieldType value) {
         return s_ControlCreators[value]();  
       }
     }  
