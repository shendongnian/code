    using System;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool Boat = false, Plane = false, Car = true;
                string ReloadBoat = "ReloadBoat", ReloadPlane = "ReloadPlane", ReloadCar = "ReloadCar";
    
                var @string = new[] { ReloadBoat, ReloadPlane, ReloadCar };
                var @bool = new[] { Boat, Plane, Car };
    
                var zip = @bool.Zip(@string, (Bool, String) => new { Bool, String })
                               .Where(i => !i.Bool)
                               .ToArray();
    
                var delimeters = zip.Select((item, index) => index != zip.Length - 1 ? ", " : " and ")
                                    .Skip(1)
                                    .Append(string.Empty);
    
                var parts = zip.Zip(delimeters, (z, d) => string.Concat(z.String, d));
                var errorMessage = string.Concat(parts);
                Console.WriteLine(errorMessage);
            }
        }
    }
