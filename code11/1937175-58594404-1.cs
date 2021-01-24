        public class Storage
        {
            private int _a;
            public int A
            {
                get { return _a; }
                set
                {
                    _a = value;
                    B = value + 5;
                }
            }
            public int B { get; set; }
            public int C { get; set; }
            public Storage()
            {
                A = 100;
            }
        }
       public class Methods
        {
            private Storage _storage;
            public Methods(Storage storage)
            {
                _storage = storage;
            }
            public void Met1()
            {
                _storage.A -= 10;
                _storage.C = _storage.A;
            }
            public void Met2()
            {
                _storage.A -= 10;
                _storage.C = _storage.A;
            }
            public void Met3()
            {
                Console.WriteLine("{0}", _storage.A);
                _storage.C = _storage.A;
                Met1();
                Met2();
                if (_storage.A > 10)
                {
                    Met3();
                }
            }
        }
Inside `Main`
            var storage = new Storage();
            Methods Test = new Methods(storage);
            Console.WriteLine("Original a value: {0}", storage.A);
            Console.WriteLine("b value: {0}", storage.B);
            Console.WriteLine("c value: {0}", storage.C);
            Test.Met1();
            Console.WriteLine("After met1: {0}", storage.A);
            Console.WriteLine("b value: {0}", storage.B);
            Console.WriteLine("c value: {0}", storage.C);
            Test.Met2();
            Console.WriteLine("After met2: {0}", storage.A);
            Console.WriteLine("b value: {0}", storage.B);
            Console.WriteLine("c value: {0}", storage.C);
            Test.Met3();
            Console.WriteLine("After met3: {0}", storage.A);
            Console.WriteLine("b value: {0}", storage.B);
            Console.WriteLine("c value: {0}", storage.C);
            storage.B += 1;
            Console.WriteLine("b value: {0}", storage.B);
[![Output from the program][1]][1]
  [1]: https://i.stack.imgur.com/shLFx.png
