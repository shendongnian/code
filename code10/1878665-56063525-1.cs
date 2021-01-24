    public abstract class Building
    {
        public string Name { get; set; }
        public float Timer { get; set; }
        
    }
    public class Farm : Building
    {
        public int CropType { get; set; }
        public Farm()
        {
        }
        public Farm(string name, int cropType, float timer)
        {
            Name = name;
            Timer = timer;
            CropType = cropType;
        }
    }
    public class Bakery : Building
    {
        public int ProductionType { get; set; }
        public bool IsOpen { get; set; }
        public Bakery()
        {
        }
        public Bakery(string name, float timer, int prodType, bool isOpen)
        {
            Name = name;
            Timer = timer;
            ProductionType = prodType;
            IsOpen = isOpen;
        }
    }
    public class Example
    {
        public static void myMethod()
        {
            Bakery bakery1 = new Bakery("Bake1", 123, 1, true);
            Farm farm1 = new Farm("Farm1", 2, 321);
            List<Building> buildings = new List<Building>();
            buildings.Add(bakery1);
            buildings.Add(farm1);
            foreach(Building building in buildings)
            {
                if(building is Farm)
                {
                    Farm f1 = (Farm)building;
                    int cropType = f1.CropType;
                }
                else if(building is Bakery)
                {
                    Bakery b1 = (Bakery)building;
                    int prodType = b1.ProductionType;
                }
            }
        }
    }
