    public Dictionary<string, Node> NodeMap { get { return nodeMap; } }
    ...
    JavaScriptSerializer ser = new JavaScriptSerializer();
    string s = ser.Serialize(graph);
    Console.WriteLine(s);
