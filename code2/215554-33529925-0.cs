    private static readonly Dictionary<Type, string> _typeToFriendlyName = new Dictionary<Type, string>
    {
        {typeof(string), "string"},
        {typeof(object), "object"},
        {typeof(bool), "bool"},
        {typeof(byte), "byte"},
        {typeof(char), "char"},
        {typeof(decimal), "decimal"},
        {typeof(double), "double"},
        {typeof(short), "short"},
        {typeof(int), "int"},
        {typeof(long), "long"},
        {typeof(sbyte), "sbyte"},
        {typeof(float), "float"},
        {typeof(ushort), "ushort"},
        {typeof(uint), "uint"},
        {typeof(ulong), "ulong"},
        {typeof(void), "void"}
    }; 
    public static string GetFriendlyName(this Type type)
    {
        string friendlyName;
        if(_typeToFriendlyName.TryGetValue(type, out friendlyName))
        {
            return friendlyName;
        }
        friendlyName = type.Name;
        if (type.IsGenericType)
        {
            int backtick = friendlyName.IndexOf('`');
            if (backtick > 0)
            {
                friendlyName = friendlyName.Remove(backtick);
            }
            friendlyName += "<";
            Type[] typeParameters = type.GetGenericArguments();
            for (int i = 0; i < typeParameters.Length; i++)
            {
                string typeParamName = typeParameters[i].GetFriendlyName();
                friendlyName += (i == 0 ? typeParamName : ", " + typeParamName);
            }
            friendlyName += ">";
        }
        return friendlyName;     
    }
    [TestFixture]
    public class TypeHelperTest
    {
        [Test]
        public void TestGetFriendlyName()
        {
            Assert.AreEqual("string", typeof(string).GetFriendlyName());
            Assert.AreEqual("KeyValuePair<int, string>", typeof(KeyValuePair<int, string>).GetFriendlyName());
            Assert.AreEqual("Tuple<int, string>", typeof(Tuple<int, string>).GetFriendlyName());
            Assert.AreEqual("Tuple<KeyValuePair<object, long>, string>", typeof(Tuple<KeyValuePair<object, long>, string>).GetFriendlyName());
            Assert.AreEqual("List<Tuple<int, string>>", typeof(List<Tuple<int, string>>).GetFriendlyName());
        }
    }
