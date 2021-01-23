    public class SomeDrop : Drop
    {
        public Dictionary<string, object> MyDictionary { get; set; }
    }
    [Test]
    public void StackOverflow()
    {
        Template.NamingConvention = new CSharpNamingConvention();
        const string template = "{{ this.MyDictionary.myKey }}";
        var someDropInstance = new SomeDrop
        {
            MyDictionary = new Dictionary<string, object> { { "myKey", 1 } }
        };
        var preparedTemplate = Template.Parse(template);
        Assert.That(
            preparedTemplate.Render(Hash.FromAnonymousObject(new { @this = someDropInstance })),
            Is.EqualTo("1"));
    }
