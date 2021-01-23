    class EvilMemberInfo : MemberInfo
    {
        public override System.Type DeclaringType
        {
            get { return null; }
        }
        // Rest omitted for brevity
    }
