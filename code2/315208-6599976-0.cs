    public class Creature
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Count { get; set; }
        public Creature(string name, string species, int count)
        {
            this.Name = name;
            this.Species = species;
            this.Count = count;
        }
        public void Add(int numToAdd)
        {
            this.Count += numToAdd;
        }
        }
    public static class CreatureStorage
    {
        private static bool isInitialized = false;
        private static List<Creature> creatureList = new List<Creature>();
        public static List<Creature> CreatureList
        {
            get {
                    if (isInitialized == false)
                    {
                        Initialize();
                    }
                    return creatureList; 
                }
            set { creatureList = value; }
        }
        public static void Add(string species, int numToAdd)
        {
            foreach (Creature creature in creatureList)
            {
                if (creature.Species.Equals(species))
                {
                    creature.Add(numToAdd);
                }
            }
        }
        private static void Initialize()
        {
            // Add code to parse through your initial list whether it's a txt file or just a string in the application
            isInitialized = true;
        }
    
