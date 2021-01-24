   string labelToFind = "Commissary ";
   var list1 = jObj.SelectTokens($"anchorEndControls[?(@.State.label == '{labelToFind}')]").ToList();
**Alternate Suggestion**
Linq is most likely a better solution since you can use queries to get specific items from your json and get corresponding values. You can get the classes for the json you are using from any of the websites such as www.json2csharp.com. 
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
1. Deserialize the object to the root class (based on the root element of your json)
2. Find the element that has the Label you are looking for
3. Use that element to look up corresponding href value.
    var jsonObj = JsonConvert.DeserializeObject<RootObject>(json);
    var element = jsonObj.anchorEndControls.Where(x => x.State.label.Equals("Law Library")).First();
    Console.WriteLine(element.State.href);
**Output**
https://apps.com
