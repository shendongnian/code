    internal class Program
    {
        #region Methods
    
        private static void Main(string[] args)
        {
            var wrap = new Wrapper { SOmeProperty = new SomeClass { Number = 007 } };
            Type type = wrap.GetType();
            
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.FieldType == typeof(SomeClass))
                {
                    Console.WriteLine("Yap!");
                }
            }
        }
    
        #endregion
    }
    
    internal class SomeClass
    {
        #region Properties
    
        public int Number { get; set; }
    
        #endregion
    }
    
    internal class Wrapper
    {
        #region Properties
    
        public SomeClass SOmeProperty { get; set; }
    
        #endregion
    }
