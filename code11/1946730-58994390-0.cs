csharp
public class BookConverter : JsonConverter<Book>
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert == typeof(Book);
    public override Book Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rootElement = JsonDocument
            .ParseValue(ref reader)
            .RootElement;
        return GetBook(rootElement);
    }
    public static Book GetBook(JsonElement jsonElement)
    {
        var id = jsonElement.GetProperty(nameof(Book.Id).FirstToLower()).GetInt32();
        var name = jsonElement.GetProperty(nameof(Book.Name).FirstToLower()).GetString();
        return new Book(id, name);
    }
    public override void Write(Utf8JsonWriter writer, Book value, JsonSerializerOptions options)
        => throw new NotImplementedException();
}
public class AuthorConverter : JsonConverter<Author>
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert == typeof(Author);
    public override Author Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rootElement = JsonDocument
            .ParseValue(ref reader)
            .RootElement;
        var id = rootElement.GetProperty(nameof(Author.Id).FirstToLower()).GetInt32();
        var firstname = rootElement.GetProperty(nameof(Author.Firstname).FirstToLower()).GetString();
        var lastname = rootElement.GetProperty(nameof(Author.Lastname).FirstToLower()).GetString();
        var books = rootElement.GetProperty(nameof(Author.Books).FirstToLower()).EnumerateArray().Select(BookConverter.GetBook).ToImmutableArray();
        return new Author(id, firstname, lastname);
    }
    public override void Write(Utf8JsonWriter writer, Author value, JsonSerializerOptions options)
        => throw new NotImplementedException();
}
