    var student = new Student()
    {
        FirstName = "FirstName",
        LastName = "LastName",
        Books = new Dictionary<string, string>
        {
            { "abc", "42" },
        }
    };
    var json = JsonConvert.SerializeObject(student);
    var xml = JsonConvert.DeserializeXNode(json, "Root");
    var result = xml.ToString(SaveOptions.None);
    // result is "<Root><books><abc>42</abc></books><Books><abc>42</abc></Books><FirstName>FirstName</FirstName><LastName>LastName</LastName></Root>"
