    public class Human 
    {
        public Human(double height)
        { 
            this.Height = height;
        }
    
        public double Height { get; set; }
     
        public void Grow(double meters) 
        {
            this.Height += rate;
        }
    }
    
    class MainClass 
    {
        public static void Main(string[] args) 
        {
            Human human = new Human(1.82);
            human.Grow(0.05);
            Console.WriteLine($"New height: {human.height}");
        }
    }
