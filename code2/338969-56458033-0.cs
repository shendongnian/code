    struct Distance
    {
        public void SetFeet(int feet) { Value = feet; }
        public void SetMiles(float miles) { Value = (int)(miles * 5280f); }
        public int GetFeet() { return Value; }
        public float GetMiles() { return Value / 5280f; }
        private int Value;
    }
    
    class Distances
    {
        public Distance Dist1;//here
        public Distance Dist2;//and here
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Distances distances = new Distances();
            distances.Dist1.SetFeet(1000);
            distances.Dist2.SetFeet(2000);
    
            Console.WriteLine("Dist1: {0}, Dist2: {1}", distances.Dist1.GetMiles(),
                distances.Dist2.GetMiles());
    
            Console.ReadLine();
        }
    }
