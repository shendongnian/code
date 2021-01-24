c#
public class LogEventPropertiesNameFormatter
{
    public void Format(LogEvent logEvent)
    {
        var keys = new List<string>(logEvent.Properties.Keys);
        foreach (var key in keys)
        {
            logEvent.AddPropertyIfAbsent(Visit(key, logEvent.Properties[key]));
            logEvent.RemovePropertyIfPresent(key);
        }
    }
    private LogEventProperty Visit(string name, LogEventPropertyValue value)
    {
        switch (value)
        {
        case null:
            throw new ArgumentNullException(nameof(value));
        case ScalarValue scalar:
            return VisitScalar(name, scalar);
        case SequenceValue sequence:
            return VisitSequence(name, sequence);
        case StructureValue scalar:
            return VisitStructure(name, scalar);
        case DictionaryValue dictionary:
            return VisitDictionary(name, dictionary);
        default:
            return new LogEventProperty(name, value);
    }
    private LogEventProperty VisitDictionary(string name, DictionaryValue dictionary)
    {
        var formattedElements = new Dictionary<ScalarValue, LogEventPropertyValue>(dictionary.Elements.Count);
        foreach (var element in dictionary.Elements)
        {
            var property = Visit(element.Key.Value.ToString(), element.Value);
            formattedElements.Add(new ScalarValue(property.Name), property.Value);
        }
        return LogEventProperty($"dict_{name}", new DictionaryValue(formattedElements));
    }
    private LogEventProperty VisitStructure(string name, StructureValue structure)
    {
        var properties = structure.Properties.Select(p => Visit(p.Name, p.Value));
        return new LogEventProperty($"struct_{name}", new StructureValue(properties));
    }
    private LogEventProperty VisitSequence(string name, SequenceValue sequence)
    {
        var elements = sequence.Elements.Select(e => Visit(null, e).Value);
        return new LogEventProperty($"seq_{name}", new SequenceValue(elements));
    }
    private LogEventProperty VisitScalar(string name, ScalarValue scalar)
    {
        return new LogEventProperty($"{GetScalarValueType(scalar)}_{name}", scalar);
    }
    private string GetScalarValueType(ScalarValue value)
    {
        switch (value.Value)
        {
            case null:
                return "null";
            case string _:
            case TimeSpan _:
                return "s";
            case int _:
            case uint _:
            case long _:
            case ulong _:
            case decimal _:
            case byte _:
            case sbyte _:
            case short _:
            case ushort _:
            case double _:
            case float _:
                return "n";
            case bool _:
                return "b";
            case DateTime _:
            case DateTimeOffset _:
                return "d";
            default:
                return "o";
        }
    }
}
public class CompactJsonFormatterTypeOverride : ITextFormatter
{
    private readonly ITextFormatter _textFormatter;
    private readonly LogEventPropertiesNameFormatter _logEventPropertiesNameFormatter;
    public CompactJsonFormatterTypeOverride()
    {
        _textFormatter = new CompactJsonFormatter();
        _logEventPropertiesNameFormatter = new LogEventPropertiesNameFormatter();
    }
    public void Format(LogEvent logEvent, TextWriter output)
    {
        _logEventPropertiesNameFormatter.Format(logEvent);
        _textFormatter.Format(logEvent, output);
    }
}
Then in the logger configuration:
c#
new LoggerConfiguration().
    WriteTo.File(new CompactJsonFormatterTypeOverride(), "log.log")
    .CreateLogger();
