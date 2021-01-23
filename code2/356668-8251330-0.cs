    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using ExpressionSerialization;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    
    namespace ExpressionSerializationTest
    {
        public static class RecursionExtensions
        {
            public static IEnumerable<int> to(this int start, int end)
            {
                for (; start <= end; start++)
                    yield return start;
            }
        }
    
        class Program
        {
            private static Expression<Func<int, int, int>> sumRange = 
                (x, y) => x.to(y).Sum();
    
            static void Main(string[] args)
            {
                const string fileName = "sumRange.bin";
    
                ExpressionSerializer serializer = new ExpressionSerializer(
                    new TypeResolver(new[] { Assembly.GetExecutingAssembly() })
                );
    
                serializer.Serialize(sumRange).Save(fileName);
    
                Expression<Func<int, int, int>> deserializedSumRange =
                    serializer.Deserialize<Func<int, int, int>>(
                        XElement.Load(fileName)
                    );
    
                Func<int, int, int> funcSumRange = 
                    deserializedSumRange.Compile();
    
                Console.WriteLine(
                    "Deserialized func returned: {0}", 
                    funcSumRange(1, 4)
                );
    
                Console.ReadKey();
            }
        }
    }
