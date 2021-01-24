    class MyCollection
    {
        List<Building> buildings;
        public MyCollection()
        {
            buildings = new List<Building>();
            buildings.Add(new Farm() { Crop = 4 });
            buildings.Add(new Mill() { Timer = 4.5f });
            buildings.Add(new Farm() { Crop = 5 });
            buildings.Add(new Farm() { Crop = 6 });
            buildings.Add(new Mill() { Timer = 42 });
            buildings.Add(new Farm() { Crop = 55 });
        }
        public void Print()
        {
            foreach (Farm f in buildings.OfType<Farm>())
            {
                Console.WriteLine(f.Crop);
            }
            foreach (Mill m in buildings.OfType<Mill>())
            {
                Console.WriteLine(m.Timer);
            }
        }
    }
