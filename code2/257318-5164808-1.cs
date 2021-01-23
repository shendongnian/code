    interface IA
    {
        void DoAnything(string name);
    }
    class A : IA
    {
        public void DoSomething()
        {
            // some code
        }
        public void DoAnything(string name)
        {
            // Some code
        }
    }
    class B : IA
    {
        public void DoNothing()
        {
            // Some code
        }
        public void DoAnything(string name)
        {
            // Some code
        }
    }
    class StorageCache : IA
    {
        private A ObjA;
        private B ObjB;
        public void DoAnything(string name)
        {
            ObjA.DoAnything(name);
            ObjB.DoAnything(name);
        }
        public void DoNothing()
        {
            ObjB.DoNothing();
        }
        public void DoSomething()
        {
            ObjA.DoSomething();
        }
    }
