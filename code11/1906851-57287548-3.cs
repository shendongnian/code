    public class DataClass
    {
        [Anonymizer(typeof(SomeAnonymizer))] 
        public string Iban { get; set; }
        [Anonymizer(typeof(NameAnonymizer))]
        public string Name { get; set; }
        public int Amount { get; set; } //No anonymization done here
    }
