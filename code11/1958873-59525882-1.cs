    string parsed = JObject.Parse(stringJson);
    foreach (var pair in parsed)
        {
            Console.WriteLine($@"{pair.Key}= ""{pair.Value}""");
        }
Please do note that JSONs are not formatted with `=`, instead with a `:`. You wont be able to deserialize it once its formatted with `=`.
You can also do this,
  Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented).Replace(":", "="));
