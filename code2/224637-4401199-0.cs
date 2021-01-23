    public class Foo
    {
        public int Counter { get; set; }
        public bool IsBool1 { get { return Counter >= 1; } }
        public bool IsBool2 { get { return Counter >= 2; } }
        public bool IsBool3 { get { return Counter >= 3; } }
        public bool IsBool4 { get { return Counter >= 4; } }
        ...
    }
