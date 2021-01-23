    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var colors = new List<Color>() { new Color("Red"), 
                                                 new Color("Yellow"), 
                                                 new Color("Blue") };
    
                var sizes = new List<Size>() { new Size("S"), 
                                               new Size("M"), 
                                               new Size("L") };
    
                var materials = new List<Material>() { new Material("Cotton"),
                                                       new Material("Nylon"),
                                                       new Material("Blend") };
    
                var products = from c in colors
                               from s in sizes
                               from m in materials
                               select new { Color = c, Size = s, Material = m };
    
    
                foreach (var p in products)
                {
                    Console.WriteLine("{0}, {1}, {2}", p.Color, p.Size, p.Material);
                }
                Console.ReadKey(true);
            }
        }
    }
