    namespace MyApp.Enums
    {
        public enum ATS_Tabs { TabOne = 0, TabTwo = 1, TabThree = 2, TabFour = 3, TabFive = 4 };
        public class ModelEnums
        {
            public static IEnumerable<Type> Types
            {
                get
                {
                    List<Type> Types = new List<Type>();
                    Types.Add(typeof(ATS_Tabs));
                    return Types;
                }
            }
        }
    }
