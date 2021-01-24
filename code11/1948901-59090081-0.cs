    namespace example_3
    {
        class TestData
        {
            public bool Trigger { get; set; }
            public int Test { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var testData = new TestData
                {
                    Test = 5,
                    Trigger = true
                };
    
                if (testData.Trigger)
                {
                    mod_test(testData);
                }
            }
    
            public static void mod_test(TestData data)
            {
                data.Test++;
                data.Trigger = false;
            }
        }
    }
