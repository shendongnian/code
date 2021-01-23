    namespace Delegates
    {
        public class Learning
        {
            /// <summary>
            /// Predicates - specialized verison of Func
            /// </summary>
            public static void Main()
            {
                List<int> list = new List<int> { 1, 2, 3 };
    
                Func<int, bool> someFunc = greaterThanTwo;
                IEnumerable<int> result = list.Where(someFunc);
    
            }
    
    
            static bool greaterThanTwo(int arg)
            {
                  return (arg > 2);
            }
    
        }
    }
