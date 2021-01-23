    public class EnumRandomizer
    {
        public static Random rand = new Random();
        public static T GetRandomValue<T>()
        {
            T[] values = Enum.GetValues(typeof(T));
            return values[rand.Next(0, values.Length)];
        }
    }
