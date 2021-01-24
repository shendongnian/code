    public class BoolYesNo
    {
        public bool Value { get; set; }
        public string YesNo { get { return Value ? "Yes" : "No"; } }
    }
    var val = new BoolYesNo() { Value = true };
    Console.WriteLine(val.Value);
    Console.WriteLine(val.YesNo);
