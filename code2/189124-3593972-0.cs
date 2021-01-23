    class Program {
        public event Action<Program> SomeEvent;
        public Action<Program> SomeField;
        static void Main(string[] args) {
            var members = typeof (Program).GetMembers();
            var eventField = members.First(mi => mi.Name == "SomeEvent");
            var normalField = members.First(mi => mi.Name == "SomeField");
            
            Console.WriteLine("eventField.MemberType: {0}", eventField.MemberType);
            Console.WriteLine("normalField.MemberType: {0}", normalField.MemberType);
        }
    }
