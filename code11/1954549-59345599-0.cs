    JObject obj = JObject.Parse(File.ReadAllText(@"C:\temp\test.txt"));
    Dictionary<string, string> dict = new Dictionary<string, string>();
    foreach (JProperty prop in obj.Properties())
    {
        dict.Add(prop.Name, obj.GetValue(prop.Name).ToObject<string>());
    };
    
    var entries = dict.Select(d =>
    string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
    string convertedString = "{" + string.Join(",", entries) + "}";
    JObject obj3 = JObject.Parse(convertedString);
obj3 will give you same object as the obj.
**Double Curly braces are internal represenation** of a Json object. You cant remove the doubly braces as thats how json is represented in a JObject. Conversion from Json to Dictionary and then back to Json works correctly in the code above.
