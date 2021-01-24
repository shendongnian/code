    public class TransferClass
    {
        public int TransferClassID { get; set; }
        public string param1{ get; set; }
        public int param2{ get; set; }
        public List<PicsClass> PicsClass{ get; set; }
    }
    public class PicsClass
    {
        public int PicsClassID{ get; set; }
        public int param1ID { get; set; }
        public int param2ID{ get; set; }
    }
