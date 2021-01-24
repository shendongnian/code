       // Overrides the ConvertTo method of TypeConverter.
       public override object ConvertTo(object value, Type destinationType) {  
          if (destinationType == typeof(byte[])) {
             // Do whatever transformation you want here
             return transformedObject;
          }
          return base.ConvertTo(value, destinationType);
       }
