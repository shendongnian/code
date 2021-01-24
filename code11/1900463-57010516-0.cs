        private static void TotalsByLength()
        {
            var tagdata = new List<TagData>() { new TagData("abs", 8), new TagData("cde", 8), new TagData("fgh", 10) };
            var categoryCounts = from p in tagdata
                                 group p.TagLength by p.TagLength into g
                                 orderby g.Count() descending
                                 select new { g.Key, TotalOccurance = g.Count() };
            foreach (var s in categoryCounts)
            {
                Console.WriteLine("{1}/{0}", s.Key, s.TotalOccurance);
            }
        }
    public class TagData
    {
        public TagData(string tagdata, int tagleng)
        {
            Tag = tagdata;
            TagLength = tagleng;
        }
        public string Tag { get; set; }      
        public int TagLength { get; set; }
    }
