c#
public class TestConfigModel
{
    public Optional<int> SomeIntValue { get; set; }
    public Optional<string> SomeStringValue { get; set; }
    public Optional<TestConfigSubsection> Subsection { get; set; }
}
With the implicit conversion operators of `Optional<T>`, you'll be able to initialize section values as normally:
c#
var config = new TestConfigModel {
    SomeIntValue = 123,
    SomeStringValue = "ABC",
    Subsection = new TestConfigSubsection {
        SomeSubsectionEnumValue = DayOfWeek.Thursday
    }
};
Generic merging logic can be implemented by introducing an `Apply` method to `Optional<T>`:
c#
Optional<T> Apply(Optional<T> partial, Func<T, T, Optional<T>> merge = null)
Every model will have to implement its own `ApplyXxxx()` method that will be passed in the `merge` parameter, like this:
c#
public class TestConfigModel
{
    // ...properties
    public Optional<TestConfigModel> ApplyModel(TestConfigModel partial)
    {
        SomeIntValue = SomeIntValue.Apply(partial.SomeIntValue);
        SomeStringValue = SomeStringValue.Apply(partial.SomeStringValue);
        Subsection = Subsection.Apply(
            partial.Subsection, 
            merge: (left, right) => left.ApplySubsection(right)); 
        return this;
    }
}
public class TestConfigSubsection
{
    // ...properties
    public Optional<TestConfigSubsection> ApplySubsection(TestConfigSubsection partial)
    {
        SomeSubsectionEnumValue = SomeSubsectionEnumValue.Apply(partial.SomeSubsectionEnumValue);
        SomeSubsectionGuidValue = SomeSubsectionGuidValue.Apply(partial.SomeSubsectionGuidValue);
        return this;
    }
}
### `Optional<T>`
Built-in implementation of `Optional<T>` is planned for C# 8, but it can be  implemented easily (mostly similar to `Nullable<T>`). 
c#
public interface IOptional
{
    bool HasValue { get; }
    object Value { get; }
}
public struct Optional<T> : IOptional
{
    private readonly bool _hasValue;
    private readonly T _value;
    public Optional(T value)
    {
        _value = value;
        _hasValue = true;
    }
    public bool HasValue => _hasValue;
    object IOptional.Value => Value;
    public T Value
    {
        get
        {
            if (!_hasValue)
            {
                throw new InvalidOperationException("has no value");
            }
            return _value;
        }
    }
    public T GetValueOrDefault() => _value;
    public T GetValueOrDefault(T defaultValue)
    {
        if (!_hasValue)
        {
            return defaultValue;
        }
        return _value;
    }
    public bool IsNullValue => _hasValue && ReferenceEquals(_value, null);
    
    public override bool Equals(object other)
    {
        if (other is Optional<T> otherOptional)
        {
            if (_hasValue != otherOptional.HasValue)
            {
                return false;
            }
            if (_hasValue)
            {
                return CompareValue(otherOptional.Value);
            }
            return true;
        }
        return false;
    }
    bool CompareValue(object otherValue)
    {
        if (_value == null)
        {
            return (otherValue == null);
        }
        return _value.Equals(otherValue);
    }
    
    public override int GetHashCode()
    {
        if (_hasValue || ReferenceEquals(_value, null))
        {
            return 0;
        }
        return _value.GetHashCode();
    }
    public override string ToString()
    {
        if (!_hasValue || ReferenceEquals(_value, null))
        {
            return "";
        }
        return _value.ToString();
    }
    public Optional<T> Apply(Optional<T> partial, Func<T, T, Optional<T>> merge = null)
    {
        if (!_hasValue && partial.HasValue)
        {
            return partial;
        }
        if (_hasValue && partial.HasValue)
        {
            if (ReferenceEquals(_value, null))
            {
                return partial.Value;
            }
            if (!ReferenceEquals(partial.Value, null))
            {
                if (merge != null)
                {
                    return merge(_value, partial.Value);
                }
                
                throw new InvalidOperationException("both values exist and merge not provided");
            }
        }
        return this;
    }
    public static implicit operator Optional<T>(T value)
    {
        return new Optional<T>(value);
    }
    public static explicit operator T(Optional<T> value)
    {
        return value.Value;
    }
}
 
### Serialization
The last thing left is to teach the serializers to handle `Optional<T>`. For instance, Newtonsoft.Json would require a custom `JsonConverter`. Below isn't a complete implementation, but it demonstrates the approach:
c#
public class OptionalConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Optional<>);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // TODO: implement properly
        // roughly the approach is like this:
        var hasValue = reader.ReadAsBoolean().GetValueOrDefault();
        var innerValue = hasValue 
            ? serializer.Deserialize(reader, objectType.GetGenericArguments([0])
            : null;
        return Activator.CreateInstance(
            objectType, 
            innerValue != null ? new[] {innerValue} : new object[0]);
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is IOptional optional)
        {
            // TODO: implement writing
        }
    }
}
