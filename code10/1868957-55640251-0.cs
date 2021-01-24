    var template = new
    {
        SomeObject = new 
        { 
            SomeProperty = new 
            {
               Id = default(int),
               Type = default(Type),
               Name = default(string)
            }
        }
    };
    var result = JsonConvert.DeserializeAnonymousType(json, template);
    var id = result.SomeObject.SomeProperty.Id;
    var type = result.SomeObject.SomeProperty.Type;
    var name = result.SomeObject.SomeProperty.Name;
