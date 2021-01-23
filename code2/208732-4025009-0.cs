    dynamic data = new ExpandoObject();
    IDictionary<string, object> dictionary = (IDictionary<string, object>)data;
    dictionary.Add("FirstName", "Bob");
    dictionary.Add("LastName", "Smith");
    Console.WriteLine(data.FirstName + " " + data.LastName);
