    namespace BlogSamples
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (Car myCar = new Car(1))
                {
                    myCar.Run();
                }
            }
        }
    }
