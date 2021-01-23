    class DoesNotWork {
        public Action ts = Frob;
        void Frob() { }
    }
    class ThisIsFine {
        public Action ts;
        public ThisIsFine() { ts = Frob; }
        void Frob();
    }
