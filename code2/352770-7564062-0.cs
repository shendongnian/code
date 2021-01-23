    public unsafe struct MyStruct {
        private fixed uint myUints[32];
        public uint[] MyUints {
            get {
                uint[] array = new uint[32];
                fixed (uint* p = myUints) {
                    for (int i = 0; i < 32; i++) {
                        array[i] = p[i];
                    }
                }
                return array;
            }
            set {
                fixed (uint* p = myUints) {
                    for (int i = 0; i < 32; i++) {
                        p[i] = value[i];
                    }
                }
            }
        }
    }
