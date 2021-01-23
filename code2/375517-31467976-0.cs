    public class StackOverflow_8152252
    {
        public static void Test()
        {
            BindingFlags instancePublicAndNot = BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic;
            var memberNames = typeof(CustomBranches)
                .GetProperties(instancePublicAndNot)
                .OfType<MemberInfo>()
                .Union(typeof(CustomBranches).GetFields(instancePublicAndNot))
                .Where(x => Attribute.IsDefined(x, typeof(DataMemberAttribute))
                         && !Attribute.IsDefined(x, typeof(NonSerializedAttribute)))
                .Select(x => x.Name);
            Console.WriteLine("All data member names");
            foreach (var memberName in memberNames)
            {
                Console.WriteLine("  {0}", memberName);
            }
        }
    
        [DataContract]
        public class CustomBranches
        {
            [DataMember]
            public int Id { get; set; }
    
            [DataMember]
            [NonSerialized]
            public string NonSerializedDataMember { get; set; }
        }
    }
