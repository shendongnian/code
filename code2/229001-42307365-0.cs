    public class Animals
    {
        private readonly string _description;
        private readonly string _speciesBinomialName;
        public string Description { get { return _description; } }
        public string SpeciesBinomialName { get { return _speciesBinomialName; } }
        
        private Animals(string description, string speciesBinomialName)
        {
            _description = description;
            _speciesBinomialName = speciesBinomialName;
        }
        private static readonly Animals _dog;
        private static readonly Animals _cat;
        private static readonly Animals _boaConstrictor;
        public static Animals Dog { get { return _dog; } }
        public static Animals Cat { get { return _cat; } }
        public static Animals BoaConstrictor { get { return _boaConstrictor; } }
        static Animals()
        {
            _dog = new Animals("Man's best friend", "Canis familiaris");
            _cat = new Animals("Small, typically furry, killer", "Felis catus");
            _boaConstrictor = new Animals("Large, heavy-bodied snake", "Boa constrictor");
        }
    }
