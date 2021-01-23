    XmlSerializer serializer = new XmlSerializer(typeof(Job));
    using (var reader = XmlReader.Create(@"d:\temp\test.xml"))
    {
        Job j = (Job)serializer.Deserialize(reader);
        Console.WriteLine(j.Process);
        Console.WriteLine(j.RelatedProcesses.Count);
        j.RelatedProcesses.ForEach(p => Console.WriteLine(p));
    }
