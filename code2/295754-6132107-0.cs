    public class Class1
    {
        // Methods
        public Class1()
        {
            this.Method1("3", "23");
        }
    
        public void Method1(string one, [Optional, DefaultParameterValue("23")] string two)
        {
        }
    }
