    public class SqlAnywhereConnectionDriver : ReflectionBasedDriver
    {
        //other code removed…
        public override bool UseNamedPrefixInSql
        {
            get { return true; }
        }
        public override bool UseNamedPrefixInParameter
        {
            get { return true; }
        }
        public override string NamedPrefix
        {
            get { return ":"; }
        }
    }
