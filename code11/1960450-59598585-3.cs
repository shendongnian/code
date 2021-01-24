    class MyLovelyClass 
    {
        private MyLovelyStruct value;
        public void Foo() 
        {
            unsafe 
            {
                var span = new Span(&value, sizeof(MyLovelyStruct));
                Process(span);
            }
        }
    }
    // Declaration 
    Process(Span<byte> span);
