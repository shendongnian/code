    public enum SubStatus { active, inactive, unset }
    public class SubItem
    {
        public SubStatus Status { get; set; }
        public string Value { get; set; }
        // Added method
        public override string ToString()
        {
            return $"Status={Status},Value={Value}";
        }
    }
