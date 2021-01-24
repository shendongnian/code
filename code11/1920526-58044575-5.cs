    internal sealed class CustomEnumConverter : JsonConverter<Foo>
    {
        public override Foo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    var isNullable = IsNullableType(typeToConvert);
                    var enumType = isNullable ? Nullable.GetUnderlyingType(typeToConvert) : typeToConvert;
                    var names = Enum.GetNames(enumType ?? throw new InvalidOperationException());
                    if (reader.TokenType != JsonTokenType.String) return Foo.Unknown;
                    var enumText = System.Text.Encoding.UTF8.GetString(reader.ValueSpan);
                    if (string.IsNullOrEmpty(enumText)) return Foo.Unknown;
                    var match = names.FirstOrDefault(e => string.Equals(e, enumText, StringComparison.OrdinalIgnoreCase));
                    return (Foo) (match != null ? Enum.Parse(enumType, match) : Foo.Unknown);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    
        public override void Write(Utf8JsonWriter writer, Foo value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    
        private static bool IsNullableType(Type t)
        {
            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
