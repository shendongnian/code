    string xml = "<Job>...xml here ";
    XDocument doc =  XDocument.Parse(xml);
    var Processess = from process in doc.Elements("Job").Elements("Process")
    
     select new
    {
        ProcessName = process.Element("Name"),
        RelatedProcesses = (from rprocess in process.Elements("RelatedProcess").Elements("Process")
                            select new
                            {
                                ProcessName = rprocess.Element("Name")
                            }
                             ).ToList()
    };
