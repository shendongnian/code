    public class AnimalType
    {
        public AnimalType(string sound)
        {
            Sound = sound;
        }
        public string Sound { get; private set; }
        private static IDictionary<Type, AnimalType> _types = new Dictionary<Type, AnimalType>();
        public static void Register(Type type, AnimalType animalType)
        {
            _types.Add(type, animalType);
        }
        public static AnimalType Get(Type type)
        {
            return _types[type];
        }
    }
