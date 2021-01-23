    ...
    Type type = typeof(Foo);
    object value = "one";
    var converter = TypeDescriptor.GetConverter(type);
    if (converter.CanConvertFrom(value.GetType()))
    {
      object newObject = converter.ConvertFrom(value);
      Console.WriteLine("Foo value: {0}", newObject.ToString());
    }
    ...
    public class FooConverter : TypeConverter
    {
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
        return sourceType == typeof(string);
      }
      public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
      {
        var name = value as string;
        if (name != null)
          return new Foo { Name = name };
        else
          return base.ConvertFrom(context, culture, value);
      }
    }
    
    [TypeConverter(typeof(FooConverter))]
    public class Foo
    {
      public string Name { get; set; }
      public override string ToString()
      {
        return Name;
      }
    }
