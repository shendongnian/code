    public class OneTwoThree
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
    }
    /// <summary>
    /// Should serialize the anonymous object
    /// and deserialize it into a strong type.
    /// </summary>
    /// <remarks>
    ///     An MVC JSON result on the server can use anonymous objects that are serialized
    ///     into strong types on a rich client.
    ///
    ///     “Making use of your JSON data in Silverlight”
    ///     [http://timheuer.com/blog/archive/2008/05/06/use-json-data-in-silverlight.aspx]
    ///
    ///     “ASP.NET MVC: Using dynamic type to test controller actions returning JsonResult”
    ///     [http://weblogs.asp.net/gunnarpeipman/archive/2010/07/24/asp-net-mvc-using-dynamic-type-to-test-controller-actions-returning-jsonresult.aspx]
    ///
    ///     “ASP.NET MVC – Unit Testing JsonResult Returning Anonymous Types”
    ///     [http://www.heartysoft.com/post/2010/05/25/ASPNET-MVC-Unit-Testing-JsonResult-Returning-Anonymous-Types.aspx]
    ///
    ///     “.NET 3.5: JSON Serialization using the DataContractJsonSerializer”
    ///     [http://pietschsoft.com/post/2008/02/NET-35-JSON-Serialization-using-the-DataContractJsonSerializer.aspx]
    /// </remarks>
    [TestMethod]
    public void ShouldSerializeAnonymousObject()
    {
        var data = new
        {
            One = "uno",
            Two = "dos",
            Three = "tres"
        };
        var result = new JsonResult
        {
            Data = data,
            ContentEncoding = Encoding.Unicode
        };
        var serializer = new JavaScriptSerializer();
        var actual = serializer.Serialize(result.Data);
        var expected = @"{""One"":""uno"",""Two"":""dos"",""Three"":""tres""}";
        Assert.AreEqual(expected, actual);
        var clientSerializer = new DataContractJsonSerializer(typeof(OneTwoThree));
        using(var stream = new MemoryStream(Encoding.Unicode.GetBytes(actual)))
        {
            var clientObject = clientSerializer.ReadObject(stream) as OneTwoThree;
            Assert.IsNotNull(clientObject);
        }
    }
    /// <summary>
    /// Should serialize the generic dictionary
    /// and deserialize it.
    /// </summary>
    [TestMethod]
    public void ShouldSerializeGenericDictionary()
    {
        var dictionary = new Dictionary<string, string>();
        dictionary.Add("One", "uno");
        dictionary.Add("Two", "dos");
        dictionary.Add("Three", "tres");
        var result = new JsonResult
        {
            Data = dictionary,
            ContentEncoding = Encoding.Unicode
        };
        var serializer = new JavaScriptSerializer();
        var actual = serializer.Serialize(result.Data);
        var expected = @"{""One"":""uno"",""Two"":""dos"",""Three"":""tres""}";
        Assert.AreEqual(expected, actual);
        var clientSerializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
        using(var stream = new MemoryStream(Encoding.Unicode.GetBytes(actual)))
        {
            var clientObject = clientSerializer.ReadObject(stream) as Dictionary<string, string>;
            Assert.IsNotNull(clientObject);
        }
    }
