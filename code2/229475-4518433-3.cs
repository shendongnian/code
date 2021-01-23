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
    }
