            public static void Main(string[] arg)
            {
                var result = from a in getA()
                             from b in getB(a)
                             select b;
                result.Start();
                Console.Write(result.Result);
            }
