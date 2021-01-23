    public class Reflector
    {
        public void ShowMembers(object o)
        {
            Type type = o.GetType();
            foreach (MemberInfo member in type.GetMembers())
            {
                Console.WriteLine("{0} is a {1}", member.Name, member.MemberType);
            }
        }
        public void Set(object o, string fieldName, int val)
        {
            MemberInfo[] info = o.GetType().GetMember(fieldName);
            FieldInfo field = info[0] as FieldInfo;
            field.SetValue(o, val);
        }
        public int x;
    }
