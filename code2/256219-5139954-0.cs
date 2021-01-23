    [StructLayout(LayoutKind.Explicit)]
        struct Int32SingleUnion
    {
        [FieldOffset(0)]
        int i;
        [FieldOffset(0)]
        float f;
        internal Int32SingleUnion(int i)
        {
            this.f = 0; // Just to keep the compiler happy
            this.i = i;
        }
        internal Int32SingleUnion(float f)
        {
            this.i = 0; // Just to keep the compiler happy
            this.f = f;
        }
        internal int AsInt32
        {
            get { return i; }
        }
        internal float AsSingle
        {
            get { return f; }
        }
    }
