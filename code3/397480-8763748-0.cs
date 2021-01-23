    [StructLayout(LayoutKind.Explicit)]
    public struct Vector3f
    {
        [FieldOffset(0)]
        private float x;
        [FieldOffset(sizeof(float))]
        private float y;
        [FieldOffset(2 * sizeof(float))]
        private float z;
        [FieldOffset(0)]
        private unsafe fixed float indexed[3];
        public Vector3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } } 
        public float Z { get { return z; } set { z = value; } }
        public unsafe float this[int index]
        {
            get
            {
                if (index < 0 || index >= 3)
                    throw new IndexOutOfRangeException();
                fixed (float* b = indexed)
                    return b[index];
            }
            set
            {
                if (index < 0 || index >= 3)
                    throw new IndexOutOfRangeException();
                fixed (float* b = indexed)
                    b[index] = value;
            }
        }
    }
