    public class Class1
    {
        private readonly Class2 SomeObject = new Class2();
        public void DoWork1(Filestream stream)
        {
            SomeObject.DoWork2(stream);
        }
    }
    public class Class2
    {
        public void DoWork2(Filestream stream)
        {
            // Do the work required with the Filestream object
        }
    }
