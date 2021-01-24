    public class Section
    {
        public string Name { get; set; }
        public string Entity { get; set; }
        public string Type { get; set; }
        public string Mode { get; set; }
        public List<Field> Fields { get; set; }
        public List<Dictionary<string, string>> Values { get; set; }
    }
    public class Field
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Type { get; set; }
        public Range Range { get; set; }
        public int Length { get; set; }
        public string Update { get; set; }
        public bool Mandatory { get; set; }
    }
    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
