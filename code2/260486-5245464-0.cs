    public class PublicStringIteration
    {
        static void Main(string[] args)
        {
            MyStrings myStrings = new MyStrings();
            foreach (string value in myStrings.GetStaticFieldValues())
            {
                Console.WriteLine(value);
            }
        }
    }
    public class MyStrings
    {
        public static string String1 = "String1 Value";
        public static string String2 = "String2 Value";
        public static string String3 = "String3 Value";
    }
    public static class MyStringsExtensions
    {
        public static IEnumerable<string> GetStaticFieldValues(this MyStrings myStrings)
        {
            Type myClassType = typeof(MyStrings);
            foreach (MemberInfo info in myClassType.GetMembers())
            {
                if (info.MemberType == MemberTypes.Field)
                {
                    yield return myClassType.GetField(info.Name).GetValue(info).ToString();
                }
            }
        }
    }
