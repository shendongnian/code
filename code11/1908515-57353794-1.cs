public interface IFormatter<T>
{
    T Convert(string x);
}
public interface IFormatter
{
    object Convert(string x);	
}
public abstract class Formatter<T> : IFormatter<T>, IFormatter
{
    public abstract T Convert(string x);
	
    object IFormatter.Convert(string x)
    {
        return Convert(x);
    }
}
public class DateTimeFormatter : Formatter<DateTime>, IFormatter
{
    public override DateTime Convert(string x)
    {
        // parse or whatever
        return DateTime.Now;		
    }
}
let your converters derive from the abstract Formatter class, and you can define your factory method like this:
public interface IConverterFactory
{
	IFormatter Create(string x);
}
public class ConverterFactory: IConverterFactory
{
    public IFormatter Create(string x)
    {
        return new DateTimeFormatter();
	}
}
Edit:
If you only ever create the formatters via the converter factory, you can remove the generic interface and method, since you won't use them anyway.
