    var data = new TestObj();
    var serializer = new DataContractSerializer(
        typeof(TestObj), null, 0x7FFFFFFF, false, true, null);
    using (var writer = new CustomWriter(Console.Out)) // Specify filename or stream instead
    {
        writer.Formatting = Formatting.Indented;
        writer.FieldList = new List<string> { "field1", "field3" }; // Specify fields to ignore
        serializer.WriteObject(writer, data);
    }
