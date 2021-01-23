    public class MyTypeConverter : TypeConverter
    {
      //Override GetStandardValuesExclusive, 
      //GetStandardValues and GetStandardValuesSupported
    }
    public class SomeClass
    {
       [TypeConverter(typeof(MyTypeConverter))]
       public Resolution SomePropertry
       {
          ...
       }
    }
