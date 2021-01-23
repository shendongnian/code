    public class A
    {
        public void B()
        {
            Console.WriteLine("B called");
            this.C();
        }
        public void C()
        {
            Console.WriteLine("C called");
        }
    }
