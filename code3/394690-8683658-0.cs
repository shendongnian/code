    private Dictionary<String, Action> actionList = new Dictionary<string, Action>();
    private void method1() { }
    private void method2() { }
          
    private void buildActionList() {
        actionList.Add("level7a", new Action(method1));
        actionList.Add("level7B", new Action(method2));
        // .. etc
    }
    public void processDoc() {
        buildActionList();
        foreach (XElement e in (XDocument.Parse(File.ReadAllText(@"C:\somefile.xml")).Elements())) {
            string name = e.Attribute("name").Value;
            if (name != null && actionList.ContainsKey(name)) {
                actionList[name].Invoke();
            }
        }
    }
