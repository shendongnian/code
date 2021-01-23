    string jsonText = @"[""Europe"", ""Asia"", ""Australia"", ""Antarctica"",
     ""North America"", ""South America"", ""Africa""]";
    using (JsonTextReader reader = new JsonTextReader(new
     StringReader(jsonText)))
    {
        while (reader.Read())
        {
            if (reader.TokenClass == JsonTokenClass.String &&
                reader.Text.StartsWith("A"))
            {
                Console.WriteLine(reader.Text);
            }
        }
    }
