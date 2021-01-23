    public class MasterClass
    {
        public string MyValue { get; set; }
        private MasterClass()
        {
        }
    
        public static MasterClass CreateMaster(string val)
        {
            MasterClass mc = new MasterClass() { MyValue = val };
            return mc;
        }
    }
