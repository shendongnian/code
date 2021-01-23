       static void Main(string[] args)
        {
            Testme t = new Testme();
            Type obj = t.GetType();
    
            MemberInfo[] objMember = obj.GetMembers();
    
           foreach (MemberInfo m in objMember)
           {
               Console.WriteLine(m);
           } 
        }
    
    
        class Testme
        {
            public String name;
            public String phone;
        }
