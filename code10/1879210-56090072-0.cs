    using Newtonsoft.Json
    
    var arg_employee = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "filter_data",
            new Dictionary<string, string>
            {
                {"user_name", "admin"},
            }
        },
    };
    
    var jsonDictionary = JsonConvert.SerializeObject(arg_employee );
