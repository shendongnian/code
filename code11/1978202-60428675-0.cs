public class MyConverter : TypeConverter
{
    ...
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string)
        {
            try{
                ... 
                return new MyClass(x);
            }
            <b>catch(Exception e){                 </b>
            <b>    throw new FormatException("Ouch: sth happens");</b>  // throw a FormatException
            <b>}</b>
        }
        return base.ConvertFrom(context, culture, value);
    }
    ...
