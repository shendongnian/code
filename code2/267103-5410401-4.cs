    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct MyStruct
    {
        public uint Field1;
        [FixedBuffer(typeof(sbyte), 10)]
        public <Field2>e__FixedBuffer0 Field2;
        public ulong Field3;
        // Nested Types
        [StructLayout(LayoutKind.Sequential, Size=10), CompilerGenerated, UnsafeValueType]
        public struct <Field2>e__FixedBuffer0
        {
           public sbyte FixedElementField;
        }
    }
 
