    public class MotorPolicy : IPolicy
    {
        public string Description { get; set; }
        public string Reg { get; set; }
        public void Display()
        {
            Console.WriteLine(string.Format("Description: {0}", Description));
            Console.WriteLine(string.Format("Reg: {0}", Reg));
        }
    }
