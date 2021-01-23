    public class EFUtils : IUtils
    {
        public bool IsNumeric(string str)
        {
            return SqlFunctions.IsNumeric(str) == 1;
        }
    }
    
    public class RepositoryUtils
    {
        protected static IUtils Utils { get; set; }
    
        static RepositoryUtils()
        {
            Utils = ObjectFactory.GetInstance<IUtils>(); //Using structureMap
        }
    
        public static bool IsNumeric(string str)
        {
            return Utils.IsNumeric(str);
        }
    }
