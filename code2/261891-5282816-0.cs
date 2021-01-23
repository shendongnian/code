    public static class ClassAConstants
    {
        public const string ConstantA = "constant_a";
        public const string ConstantB = "constant_b";
    }
    public static class ClassBConstants
    {
        public static string ConstantA
        {
            get { return ClassAConstants.ConstantA; }
        }
        public static string ConstantB
        {
            get { return ClassAConstants.ConstantB; }
        }
        public const string ConstantC = "constant_c";
        public const string ConstantD = "constant_d";
    }
