    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OrdinalPositionAttribute : Attribute
    {
        public int Position { get; private set; }
        public OrdinalPositionAttribute(int position)
        {
            Position = position;
        }
    }
    public class DocMetaData
    {
        public const string SEPARATOR = "\t";       // horizontal tab is delimiter
        public const string CARRIAGE_RETURN = "\r";
        [OrdinalPosition(0)]
        public string Section { get; set; }
        [OrdinalPosition(1)]
        public string DocClass { get; set; }
        [OrdinalPosition(2)]
        public string Meeting { get; set; }
        [OrdinalPosition(3)]
        public string Agency { get; set; }
        [OrdinalPosition(4)]
        public string Country { get; set; }
        [OrdinalPosition(5)]
        public string Comment { get; set; }
        [OrdinalPosition(6)]
        public string Title { get; set; }
        [OrdinalPosition(7)]
        public string Folder { get; set; }
        [OrdinalPosition(8)]
        public string File { get; set; }
        private void OutputColumnNamesAsFirstLine(StreamWriter writer)
        {
            StringBuilder md = new StringBuilder();
            var columns = Utility.GetOrderedMembers(typeof(DocMetaData));
            int i = 0;
            foreach (var columnName in columns)
            {
                i++;
                md.Append(columnName.Name); md.Append(DocMetaData.SEPARATOR);
            }
            writer.WriteLine(md.ToString());
        }
    }
    public static class Utility
    {
        public static IEnumerable<MemberInfo> GetOrderedMembers(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            return CreateGetOrderedMembersEnumerable(type);
        }
        private static IEnumerable<MemberInfo> CreateGetOrderedMembersEnumerable(Type type)
        {
            return from member in type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                   let ordinal = member.GetCustomAttributes(typeof(OrdinalPositionAttribute), true)
                                       .OfType<OrdinalPositionAttribute>().FirstOrDefault()
                   where ordinal != null
                   orderby ordinal.Position ascending
                   select member;
        }
    }
