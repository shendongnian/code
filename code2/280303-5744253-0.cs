    public class Test : List<Int32>
    {
        public String Name { get { return this.ToString(); } }
        public override string ToString()
        {
            return "Test";
        }
    }
