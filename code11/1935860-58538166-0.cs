    public class Engine
            {
                public static string Size;
                public static int HorsePower;
                public static float FuelConsumtionRate;
        
                //Constructor to set fuel reate
                public Engine(float fuelRate)
                {
                    FuelConsumtionRate = fuelRate;
                }
                public Engine(string cylinder, int hp, float fuelRate)
                {
                    Size = cylinder;
                    Console.WriteLine($"Engine type: {cylinder}");
                    HorsePower = hp;
                    Console.WriteLine($"Horse power: {hp} hp");
                    FuelConsumtionRate = fuelRate;
                    Console.WriteLine($"Fuel consumption: {fuelRate} l/h");
                }
