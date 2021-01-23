    public void Test()
    {
        // Your template is simpler
        string template = "Hi {Name.First}";
        // some JSON
        string data = @"{""Name"":{""First"":""Jack"",""Last"":""Smith""}}";
    
        JavaScriptSerializer jss = new JavaScriptSerializer();
    
        // now `d` contains all the values you need, in a dictionary
        dynamic d = jss.Deserialize(data, typeof(object));
    
        // running your template against a regex to
        // extract the tokens that need to be replaced
        var result = Regex.Replace(template, @"{?{([^}]+)}?}", (m) =>
            {
                // Skip escape values (ex: {{escaped value}} )
                if (m.Value.StartsWith("{{"))
                    return m.Value;
                // split the token by `.` to run against the dictionary
                var pieces = m.Groups[1].Value.Split('.');
                dynamic value = d;
                // go after all the pieces, recursively going inside
                // ex: "Name.First"
                // Step 1 (value = value["Name"])
                //    value = new Dictionary<string, object>
                //    {
                //        { "First": "Jack" }, { "Last": "Smith" }
                //    };
                // Step 2 (value = value["First"])
                //    value = "Jack"
                foreach (var piece in pieces)
                {
                    value = value[piece]; // go inside each time
                }
    
                return value;
            });
    }
