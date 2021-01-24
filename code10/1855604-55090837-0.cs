    public class Tiger : Animal
    {
        public int Legs { get; set; }
        public Tiger(int age, string color, float speed) : base(age,color,speed)
        {
            Legs = this.Legs;
        }
    }
