    [Flags]
    public enum TestParams { Param1 = 1, Param2 = 2, Param3 = 4, All = Param1 | Param2 | Param3 };
    public class ParamsAttribute : Attribute {
        readonly TestParams params;
        public ParamsAttrbiute (TestParams params) {
            this.params = params;
        }
        public TestParams Params { get { return params; } }
    } 
