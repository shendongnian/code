        struct A
        {
            public int Value { get; set; }
        }
        Main()
        {
            A number = new A();
            number.Value = 9;
            Console.WriteLine(number.Value)
        }
