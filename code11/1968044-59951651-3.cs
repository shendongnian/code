    public class DoorType
    {
        public DoorType(List<string> values, string name)
        {
            Values = values;
            Name = name;
        }
        public string Name { get; }
        public List<string> Values { get; }
    }
    public static List<DoorType> doorTypes = new List<DoorType>
    {
        new DoorType(standard, nameof(standard)),
        new DoorType(original, nameof(original))
    };
