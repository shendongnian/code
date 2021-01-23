    struct MyStruct
    {
        int a = 1;
        int b = 2;
        int c = 3;
        public void Mutate()
        {
            a = 10;
            b = 20;
            c = 30;
        }
        public void Reset()
        {
            a = 1;
            b = 2;
            c = 3;
        }
        public void Reset2()
        {
            this = new MyStruct();
        }
        // The two Reset methods are equivilent...
    }
