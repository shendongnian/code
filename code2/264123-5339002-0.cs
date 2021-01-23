    class Program
    {
        class Test
        {
            public int A { get; set; }
        }
    
        static void Main(string[] args)
        {
            var testA = new Test { A = 1 };
            var testB = new Test { A = 1 };
    
            var propertyInfo = typeof(Test).GetProperties().Where(p => p.Name == "A").Single();
    
            var valueA = propertyInfo.GetValue(testA, null);
            var valueB = propertyInfo.GetValue(testB, null);
    
            var result = valueA == valueB; // False
            var resultEquals = valueA.Equals(valueB); // True
    
        }
    }
