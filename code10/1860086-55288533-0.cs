    class Program
    {
        static void Main(string[] args)
        {
            //c# will automatically pick best match by give parameter.
            Console.WriteLine("1 + 2 = " + Numeric.Instance.Calculate("Sum", 1, 2));
            Console.WriteLine("Max(1, 2) = " + Numeric.Instance.Calculate("Max", 1.5, 2.1));
            Console.ReadLine();
        }
        interface INumeric<T>
        {
            T Sum(T a, T b);
            T Max(T a, T b);
            T Min(T a, T b);
            ///// <summary>
            ///// This works only in .NET core 3.0, c# 8.0.
            ///// </summary>
            ///// <param name="method"></param>
            ///// <param name="a"></param>
            ///// <param name="b"></param>
            ///// <returns></returns>
            //public virtual T Calculate(string method, T a, T b)
            //{
            //    switch (method)
            //    {
            //        case "Sum":
            //            {
            //                return Sum(a, b);
            //            }
            //        case "Max":
            //            {
            //                return Sum(a, b);
            //            }
            //        case "Min":
            //            {
            //                return Sum(a, b);
            //            }
            //        default:
            //            {
            //                throw new NotImplementedException($"Method '{method}' is not supported.");
            //            }
            //    }
            //}
        }
        struct Numeric :
            INumeric<int>,
            INumeric<double>,
            INumeric<long>
        {
            public double Sum(double a, double b) => a + b;
            public double Max(double a, double b) => Math.Max(a, b);
            public double Min(double a, double b) => Math.Min(a, b);
            public int Sum(int a, int b) => a + b;
            public int Max(int a, int b) => Math.Max(a, b);
            public int Min(int a, int b) => Math.Min(a, b);
            public long Sum(long a, long b) => a + b;
            public long Max(long a, long b) => Math.Max(a, b);
            public long Min(long a, long b) => Math.Min(a, b);
            public int Calculate(string method, int a, int b)
            {
                switch (method)
                {
                    case "Sum":
                        {
                            return Sum(a, b);
                        }
                    case "Max":
                        {
                            return Sum(a, b);
                        }
                    case "Min":
                        {
                            return Sum(a, b);
                        }
                    default:
                        {
                            throw new NotImplementedException($"Method '{method}' is not supported.");
                        }
                }
            }
            public double Calculate(string method, double a, double b)
            {
                switch (method)
                {
                    case "Sum":
                        {
                            return Sum(a, b);
                        }
                    case "Max":
                        {
                            return Sum(a, b);
                        }
                    case "Min":
                        {
                            return Sum(a, b);
                        }
                    default:
                        {
                            throw new NotImplementedException($"Method '{method}' is not supported.");
                        }
                }
            }
            public long Calculate(string method, long a, long b)
            {
                switch (method)
                {
                    case "Sum":
                        {
                            return Sum(a, b);
                        }
                    case "Max":
                        {
                            return Sum(a, b);
                        }
                    case "Min":
                        {
                            return Sum(a, b);
                        }
                    default:
                        {
                            throw new NotImplementedException($"Method '{method}' is not supported.");
                        }
                }
            }
            public static Numeric Instance = new Numeric();
        }
    }
