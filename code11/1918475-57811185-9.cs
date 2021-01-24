    static void Main(string[] args)
        {
            int TestFunc<T>(T data)
            {
                return 1;
            }
            dynamic d = 2;
            var r = TestFunc(d);
        }
