    public class XMLResult()
    {
        public string localname;
        public int Units;
    }
    IEnumerable<XMLResult> results = from el in root.Descendants(aw + "StDteRange ") 
         select new XMLResult() {
              Name = el.Element("strtTime").value,
              Units = el.Element("numOfUnits").value
         };
