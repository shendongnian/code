    public class ChipConverter : CustomCreationConverter<Chip>
    {
        public override Chip Create(Type objectType)
        {
            return (Chip)Activator.CreateInstance(typeof(Chip), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { 0, 0 }, null); 
        }
    }
