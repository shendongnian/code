    public enum InfringementCategory
    {
        [EnumNamedConstant(Description = "INF0001")]
        Infringement,
        [EnumNamedConstant(Description = "INF0002")]
        OFN
    }
    public class Test{
        public void Test()
        {
            String result = InfringementCategory.Infringement.GetDescription();
        }
    }
