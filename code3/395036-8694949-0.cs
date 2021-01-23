    void delegate XYZ(int p);
    interface IXyz {
        void doit(int p);
    }
    class One {
        // All four methods below can be used to implement the XYZ delegate
        void XYZ1(int p) {...}
        void XYZ2(int p) {...}
        void XYZ3(int p) {...}
        void XYZ4(int p) {...}
    }
    class Two : IXyz {
        public void doit(int p) {
            // Only this method could be used to call an implementation through an interface
        }
    }
    
