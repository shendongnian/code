    using System;
    
    [AttributeUsage(AttributeTargets.All)]
    class SampleAttribute : Attribute
    {
        private bool hasFlag = false;
        public bool HasFlag { get { return hasFlag; } }
        
        private bool flag = false;
        public bool Flag
        {
            get { return flag; }
            set
            {
                flag = value;
                hasFlag = true;
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            foreach (var method in typeof(Test).GetMethods())
            {
                var attributes = (SampleAttribute[])
                    method.GetCustomAttributes(typeof(SampleAttribute), false);
                if (attributes.Length > 0)
                {
                    Console.WriteLine("{0}: Flag={1} HasFlag={2}",
                                      method.Name,
                                      attributes[0].Flag,
                                      attributes[0].HasFlag);
                }
            }
        }
        
        [Sample(Flag = true)]
        public static void WithFlagTrue() {}
    
        [Sample(Flag = false)]
        public static void WithFlagFalse() {}
    
        [Sample]
        public static void WithoutFlag() {}
    }
