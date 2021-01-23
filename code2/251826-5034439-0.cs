    public partial class MyComboBox : ComboBox
    {
        public enum Multipliers { B = 1, KB = 2, MB = 10, GB = 20, TB = 30 }
        public string SuperType { get; set; }
        public bool Global { get; set; }
        public Multipliers myMultiplierProperty {get; set;}
    }
