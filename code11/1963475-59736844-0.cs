    public class State
    {
        public int clickAction { get; set; }
        public string image { get; set; }
        public bool showLabel { get; set; }
        public string label { get; set; }
        public string href { get; set; }
        public bool favicon { get; set; }
    }
    public class AnchorEndControl
    {
        public State State { get; set; }
        public int type { get; set; }
        public List<object> mergeStyles { get; set; }
    }
    public class RootObject
    {
        public List<AnchorEndControl> anchorEndControls { get; set; }
    }
**Usage**
    var jsonObj = JsonConvert.DeserializeObject<RootObject>(json);
    var element = jsonObj.anchorEndControls.Where(x => x.State.label.Equals("Law Library")).First();
    Console.WriteLine(element.State.href);
**Output**
https://apps.com
