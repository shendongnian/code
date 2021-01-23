    class MillionExpression : TerminalExpression
    {
        public override string One() { return "m"; }
        public override string Four() { return ""; }
        public override string Five() { return ""; }
        public override string Nine() { return ""; }
        public override int Multiplier() { return 1000000; }
    }
    class HundredThousandExpression : TerminalExpression
    {
        public override string One() { return "c"; }
        public override string Four() { return "cd"; }
        public override string Five() { return "d"; }
        public override string Nine() { return "cm"; }
        public override int Multiplier() { return 100000; }
    }
    class ThousandExpression : TerminalExpression
    {
        public override string One() { return "M"; }
        public override string Four() { return "Mv"; }
        public override string Five() { return "v"; }
        public override string Nine() { return "Mx"; }
        public override int Multiplier() { return 1000; }
    }
    class HundredExpression : TerminalExpression
    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }
    class TenExpression : TerminalExpression
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }
    class OneExpression : TerminalExpression
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }
