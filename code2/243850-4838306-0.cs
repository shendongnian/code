    class BassClass
    {
         public string GetValueOfSomething()
         {
            Type type = this.GetType();
            MemberInfo[] members = type.GetMembers();
            ...
        }
    }
