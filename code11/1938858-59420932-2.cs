    [Fact]
    public void ArrayTest()
    {
        var structs = new[] {new MyStruct()};
        structs[0].Type++;
        
        ref var @struct = ref structs[0];
        @struct.Type++;
        // Test passes the value was incremented twice, because reference was used.
        structs[0].Type.Should().Be(2);
    }
    [Fact]
    public void MyArrayTest()
    {
        var structs = new MyArray<MyStruct>(new[] {new MyStruct()});
        // Compiler error, but was possible in earlier versions of C#
        // and would not modify the item in the array,
        // because value was copied before modification.
        // structs[0].Type++;
        var @struct = structs[0];
        @struct.Type++;
        // Value wasn't incremented, because it was copied on the stack.
        structs[0].Type.Should().Be(0);
    }
    [Fact]
    public void MyRefArrayTest()
    {
        var structs = new MyRefArray<MyStruct>(new[] {new MyStruct()});
        structs[0].Type++;
        ref var @struct = ref structs[0];
        @struct.Type++;
        // Test passes the value was incremented twice, because reference was used.
        structs[0].Type.Should().Be(2);
    }
    struct MyStruct
    {
        public int Type { get; set; }
    }
    class MyArray<T>
    {
        private T[] data;
        public MyArray(in T[] array)
        {
            data = new T[array.Length];
            Array.Copy(array, data, array.Length);
        }
        public T this[int i]
        {
            get => data[i];
            set => data[i] = value;
        }
    }
    class MyRefArray<T>
    {
        private T[] data;
        public MyRefArray(in T[] array)
        {
            data = new T[array.Length];
            Array.Copy(array, data, array.Length);
        }
        public ref T this[int i]
        {
            get => ref data[i];
            // Compiler error, ref indexer cannot have setter.
            // set => data[i] = value;
        }
    }
