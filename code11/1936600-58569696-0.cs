 ini
BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i5-3317U CPU 1.70GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), X64 RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), X64 RyuJIT
|     Method |        Mean |     Error |    StdDev |
|----------- |-------------|-----------|-----------|
|   Instance |    41.61 ns |  0.309 ns |  0.274 ns |
| Reflection | 3,321.40 ns | 28.379 ns | 25.157 ns |
This clearly shows that your reflection code is around 80 times slower than using an object initializer.
@ASh's answer talks about why your benchmark is flawed, so I won't replicate that here - see their answer.
Benchmark code:
    public class Benchmark
    {
        [Benchmark]
        public TestClass Instance()
        {
            TestClass testClass = new TestClass
            {
                PropertyOne = "PropertyOne",
                PropertyTwo = "PropertyTwo",
                PropertyThree = "PropertyThree",
                PropertyFour = "PropertyFour",
                PropertyFive = "PropertyFive)",
                PropertySix = "PropertySix",
                PropertySeven = "PropertySeven",
                PropertyEight = "PropertyEight",
                PropertyNine = "PropertyNine",
                PropertyTen = "PropertyTen"
            };
            return testClass;
        }
        [Benchmark]
        public TestClass Reflection()
        {
            TestClass testClass = new TestClass();
            Type type = testClass.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                switch (propertyInfo.Name)
                {
                    case nameof(testClass.PropertyOne) :
                        propertyInfo.SetValue(testClass, "PropertyOne");
                        break;
                    case nameof(testClass.PropertyTwo) :
                        propertyInfo.SetValue(testClass, "PropertyTwo");
                        break;
                    case nameof(testClass.PropertyThree) :
                        propertyInfo.SetValue(testClass, "PropertyThree");
                        break;
                    case nameof(testClass.PropertyFour) :
                        propertyInfo.SetValue(testClass, "PropertyFour");
                        break;
                    case nameof(testClass.PropertyFive) :
                        propertyInfo.SetValue(testClass, "PropertyFive");
                        break;
                    case nameof(testClass.PropertySix) :
                        propertyInfo.SetValue(testClass, "PropertySix");
                        break;
                    case nameof(testClass.PropertySeven) :
                        propertyInfo.SetValue(testClass, "PropertySeven");
                        break;
                    case nameof(testClass.PropertyEight) :
                        propertyInfo.SetValue(testClass, "PropertyEight");
                        break;
                    case nameof(testClass.PropertyNine) :
                        propertyInfo.SetValue(testClass, "PropertyNine");
                        break;
                    case nameof(testClass.PropertyTen) :
                        propertyInfo.SetValue(testClass, "PropertyTen");
                        break;
                }
            }
            return testClass;
        }
    }
    class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
