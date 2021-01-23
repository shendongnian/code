    public class UpdateAnimalViewModel
    {
        public int Size { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public int SizeOfTeeth { get; set; }
    }
    public class UpdateElephantViewModel : UpdateAnimalViewModel
    {
        public int TrunkLength { get; set; }
        public string Personality { get; set; }
    }
