    public class Foo
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        private readonly ByteArrayComparer _comparer = new ByteArrayComparer();
        public override bool Equals(object obj)
        {
            var foo = obj as Foo;
            return foo != null &&
                Id == foo.Id &&
                _comparer.Equals(Data, foo.Data);
        }
    }
