    public class MyMySqlProvider : MembershipProvider
    {
        private MySQLMembershipProvider mySqlImpl = new MySQLMembershipProvider();
        public override void Initialize(string name, NameValueCollection configs) 
        {
            mySqlImpl.Initialize(name, configs);
            base.Initialie(name, configs);
        }
        public override bool OverrideSomethingElse()
        {
            bool someBool = mySqlImpl.OverrideSomethingElse();
            if (someBool)
            {
                //someBool = adapt to something else;
            }
            return someBool;
        }
    }
