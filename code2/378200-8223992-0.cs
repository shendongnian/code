    public static class Extensions
    {
        public static T ToEnum<T>(this string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }
    }
    public enum TestEnum
    {
        None,
        Special,
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = TestEnum.Special.ToString();
            var y = x.ToEnum<TestEnum>(); // y will be TestEnum.Special
        }
    }
