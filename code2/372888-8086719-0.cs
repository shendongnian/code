    public class Appropriate
    {
        public string Value { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
---
    IList<Appropriate> list = new List<Appropriate>();
    
    foreach(var item in dataViewer) {
        list.Add(new Appropriate() {
            Value = item["value"],
            Start = item["start"],
            End = item["end"]
        });
    }
