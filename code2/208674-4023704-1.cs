    XmlSerializer x = new XmlSerializer(typeof(Job));
    using (var w = XmlReader.Create(@"d:\temp\test.xml"))
    {
        Job j = (Job)x.Deserialize(w);
        Console.WriteLine(j.Process);
        Console.WriteLine(j.RelatedProcesses.Count);
        j.RelatedProcesses.ForEach(p => Console.WriteLine(p));
    }
