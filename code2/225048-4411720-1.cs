    class DoesNotWork {
        public Action ts = Frob; // doesn't work, cannot access non-static method 
        void Frob() { }
    }
    class ThisIsFine {
        public Action ts;
        public ThisIsFine() { ts = Frob; }
        void Frob();
    }
