    [TypeConverter(typeof(CompactButtonTypeConverter))]
    public class CompactButton: ... {
      ...
    }
    
    public class CompactButtonTypeConverter: TypeConverter {
     
      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
        if (destinationType == typeof(InstanceDescriptor)) 
           return true;
        return base.CanConvertTo(context, destinationType);
      }
    
      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
        if (destinationType == typeof(InstanceDescriptor) && value is CompactButton) {
          // This assumes you have a public default constructor on your type.
          ConstructorInfo ctor = typeof(CompactButton).GetConstructor();
          if (ctor != null) 
             return new InstanceDescriptor(ctor, new object[0], false);
        }
        return base.ConvertTo(context, culture, value, destinationType);      
      }
     
    }
