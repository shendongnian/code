    public class Zahlungsart : EnumBase<int, Zahlungsart>
    {
        public static readonly Zahlungsart Erlagsschein;
        public static readonly Zahlungsart Lastschrift;
    
        static Zahlungsart()
        {
            Erlagsschein = new Zahlungsart("Erlagsschein", 0);
            Lastschrift = new Zahlungsart("Lastschrift", 1);
        }
    
        private Zahlungsart(string text, int value) : base(text, value) { }
        public static new IEnumerable<Zahlungsart> ItemList { get { return EnumBase<int, Zahlungsart>.ItemList; } }
    }
