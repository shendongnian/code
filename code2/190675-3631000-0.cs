    var doc = XDocument.Load("xmlfile1.xml");
    var steps = from step in doc.Root.Elements("step")
                select new Step
                       {
                           Id       = (int)step.Element("id"),
                           BackId   = (int)step.Element("backid"),
                           Question = (string)step.Element("question"),
                           YesId    = (int)step.Element("yesid"),
                           NoId     = (int)step.Element("noid"),
                       };
    var dict = steps.ToDictionary(step => step.Id);
    Console.WriteLine(dict[3].Question);
