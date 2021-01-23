    public class XMLResult()
    {
        public string localname;
        public int Units;
    }
    IEnumerable<XMLResult> results = from el in root.Descendants(aw + "StDteRange ") 
         select new XMLResult() {
              Name = el.Element("name").value,
              Units = el.Element("name").value
         };
