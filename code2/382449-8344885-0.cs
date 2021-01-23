    private class MyReader : BinaryReader, IDisposable
        {
            private readonly Stream _input;
            public MyReader(Stream input) : base(input)
            {
                _input = input;
            }
            void IDisposable.Dispose()
            {
                Dispose();
                _input.Dispose();
            }
        }
