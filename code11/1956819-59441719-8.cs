    struct Vector3
    {
        public float x;
        public float y;
        public float z;
        public ref float this[Int32 i]
        {
            get
            {
                switch( i )
                {
                case 0: return ref this.x;
                case 1: return ref this.y;
                case 2: return ref this.z;
                default: throw new ArgumentOutOfRangeException( nameof(i) );
                }
            }
        }
    }
