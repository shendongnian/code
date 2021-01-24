csharp
public class ItemWithNameAndAttributesTests_Theories
{
    [Theory]
    [InlineData("Name", new [] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" })]
    [InlineData("Name", new string[0])]
    public void Verify_Constructor_PropertiesAreEqualToInput(string name, string[] attributes)
    {
        var itemWithNameAndAttributes = new ItemWithNameAndAttributes(name, new List<string>(attributes));
        Assert.Equal(name, itemWithNameAndAttributes.Name);
        Assert.Equal(attributes, itemWithNameAndAttributes.Attributes);
    }
    [Theory]
    [InlineData("", new [] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" }, typeof(ArgumentException))]
    [InlineData(null, new [] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" }, typeof(ArgumentNullException))]
    [InlineData("Name", null, typeof(ArgumentNullException))]
    public void Verify_Constructor_ThrowException(string name, string[] attributes, Type exceptionType)
    {
        Assert.Throws(exceptionType, () => new ItemWithNameAndAttributes(name, attributes));
    }
    [Theory]
    [InlineData("Name", new [] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" }, false, "(Item 1) (Item 2) (Item 3) (Item 4) (Item 5)")]
    [InlineData("Name", new [] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" }, true, " (Item 1) (Item 2) (Item 3) (Item 4) (Item 5)")]
    [InlineData("Name", new string[0], false, "")]
    [InlineData("Name", new string[0], true, "")]
    public void Verify_AttributesToParenthesesString(string name, string[] attributes, bool prependSpace, string expected)
    {
        var itemWithNameAndAttributes = new ItemWithNameAndAttributes(name, attributes);
        var result = itemWithNameAndAttributes.AttributesToParenthesesString(prependSpace);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("Name", new [] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" }, "Name (Item 1) (Item 2) (Item 3) (Item 4) (Item 5)")]
    [InlineData("Name", new string[0], "Name")]
    public void Verify_ToString(string name, string[] attributes, string expected)
    {
        var itemWithNameAndAttributes = new ItemWithNameAndAttributes(name, attributes);
        var result = itemWithNameAndAttributes.ToString();
        Assert.Equal(expected, result);
    }
}
While writing that example, I noticed that `Verify_AttributesToParenthesesString` is somewhat redundant with `Verify_ToString`--testing `ToString` implicitly tests `AttributesToParenthesesString`. If `AttributesToParenthesesString` exists only to support `ToString`, then it's an implementation detail. The code can be simplified by deleting `Verify_AttributesToParenthesesString` and changing `AttributesToParenthesesString`'s access to `protected`.
