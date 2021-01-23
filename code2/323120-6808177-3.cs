    public class DataBaseConfigurationTest : DataBaseConfiguration
    {
        public int TimesCalled { get; set; }
        public string LastNameStored { get; set; }
    
        public DataBaseConfigurationTest()
        {
            TimesCalled = 0;
        }
    
        public override void Store(string name)
        {
            TimesCalled++;
            LastNameStored = name;
        }
    }
