        private static readonly Dictionary<Type, string> _typeToFriendlyName = new Dictionary<Type, string>
        {
            { typeof(string), "string" },
            { typeof(object), "object" },
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(short), "short" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(sbyte), "sbyte" },
            { typeof(float), "float" },
            { typeof(ushort), "ushort" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            { typeof(void), "void" }
        };
        public static string GetFriendlyName(this Type type)
        {
            string friendlyName;
            if (_typeToFriendlyName.TryGetValue(type, out friendlyName))
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
            if (type.IsArray)
            {
                return type.GetElementType().GetFriendlyName() + "[]";
            }
            return friendlyName;
        }
    [TestFixture]
    public class TypeHelperTest
    {
        [Test]
        public void TestGetFriendlyName()
        {
            Assert.AreEqual("string", typeof(string).FriendlyName());
            Assert.AreEqual("int[]", typeof(int[]).FriendlyName());
            Assert.AreEqual("int[][]", typeof(int[][]).FriendlyName());
            Assert.AreEqual("KeyValuePair<int, string>", typeof(KeyValuePair<int, string>).FriendlyName());
            Assert.AreEqual("Tuple<int, string>", typeof(Tuple<int, string>).FriendlyName());
            Assert.AreEqual("Tuple<KeyValuePair<object, long>, string>", typeof(Tuple<KeyValuePair<object, long>, string>).FriendlyName());
            Assert.AreEqual("List<Tuple<int, string>>", typeof(List<Tuple<int, string>>).FriendlyName());
            Assert.AreEqual("Tuple<short[], string>", typeof(Tuple<short[], string>).FriendlyName());
        }
    }
