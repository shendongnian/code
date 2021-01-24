    public interface IFormatService
    {
        string FormatValue(object value);
    }
    public class FormatService : IFormatService
    {
        public string FormatValue(object value)
        {
            dynamic valueAsDynamic = value;
            return FormatValueDynamic(valueAsDynamic);
        }
        string FormatValueDynamic(dynamic value) => FormatValuePrivate(value);
        string FormatValuePrivate(DateTime value) => "DateTimeFormatter";
        string FormatValuePrivate(decimal value) => "CurrencyFormatter";
        string FormatValuePrivate(object value) => throw new NotSupportedException();
    }
