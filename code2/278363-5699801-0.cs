    public static class Serialization
    {
        private static void ValidateSerializable(this Type type)
        {
            bool isSerializable = !typeof(ISerializable).IsAssignableFrom(type);
            bool hasSerilizationAttribute = type.GetCustomAttributes(typeof(SerializableAttribute), false).Length == 1;
            if (!isSerializable && !hasSerilizationAttribute)
                throw new SerializationException("'{0}' is not marked as serializable!".FormatWith(type.FullName));
        }
        public static void SerializeToBinaryFile(this object instance, string path)
        {
            instance.GetType().ValidateSerializable();
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, instance);
            }
        }
        public static T DeserializeFromBinaryFile<T>(string path) where T : class
        {
            typeof(T).ValidateSerializable();
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                IFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(stream);
            }
        }
        public static string FormatWith(this string instance, params  object[] arguments)
        {
            return string.Format(instance, arguments);
        }
    }
    [Serializable]
    public class User
    {
        public string FirstName { get; set; }
    }
    class Program
    {
        protected void Main(string[] argv)
        {
            User user = new User {FirstName = "Jonas"};
            user.SerializeToBinaryFile("myUser.bin");
            User deserializedUser = Serialization.DeserializeFromBinaryFile<User>("myUser.bin");
        }
    }
