    XmlSerializer serializer = new XmlSerializer(typeof(RundateCollection));
    StringWriter sw = new StringWriter();
    rundate myRunDate = new rundate() { LeaveCreditingMonth = "A", IncludeNoTimesheet = "B", LeaveCreditingYear = "C" };
    RundateCollection ra = new RundateCollection() { Rundates = new List<rundate>() { myRunDate } };
    serializer.Serialize(sw, ra);
    string xmlSerialized = sw.GetStringBuilder().ToString();
    string xml = File.ReadAllText(@"test.xml");
    StringReader sr = new StringReader(xml);
    var rundateCollection = serializer.Deserialize(sr);
