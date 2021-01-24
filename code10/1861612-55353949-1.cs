    string input = "{\"ENVELOPE\":{\"STUDENTLIST\":{\"STUDENT\":[\"John\",\"HHH\"]}}}";
    // string input = "{\"ENVELOPE\":{\"STUDENTLIST\":{\"STUDENT\":\"John\"}}}";
    // string input = "{\"RESPONSE\":{\"LINEERROR\":\"Could not find Students\"}}";
    
    JObject jObj = JObject.Parse(input);
    if (jObj["RESPONSE"] != null)
    {
        string error = jObj["RESPONSE"]["LINEERROR"].ToString();
        Console.WriteLine($"Error: {error}");
    
        // or throw an exception
        return;
    }
    
    var studentNames = new List<string>();
    
    // If there is no error, there should be a student prpoerty.
    var students = jObj["ENVELOPE"]["STUDENTLIST"]["STUDENT"];
    if (students is JArray)
    {
        // If the student property is an array, add all names to the list.
        var studentArray = students as JArray;
        studentNames.AddRange(studentArray.Select(s => s.ToString()));
    }
    else
    {
        // If student property is a string, add that to the list.
        studentNames.Add(students.ToString());
    }
    
    foreach (var student in studentNames)
    {
        // Doing something with the names.
        Console.WriteLine(student);
    }
