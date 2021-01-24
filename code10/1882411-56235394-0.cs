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
    
                var zip = @bool.Zip(@string, (Bool, String) => new { Bool, String });
    
                var filtered = zip.Where(i => !i.Bool).ToArray();
                var delimeters = filtered.Select((item, index) => index != filtered.Length - 1 ? ", " : " and ").Skip(1).Append(string.Empty);
                var parts = filtered.Zip(delimeters, (f, d) => string.Concat(f.String, d));
                var errorMessage = string.Concat(parts);
            }
        }
    }
