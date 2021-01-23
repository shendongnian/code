        static SomeDataObject DefaultData;
        private Lazy<SomeDataObject> dataA = new Lazy<SomeDataObject>(() => DefaultData, LazyThreadSafetyMode.ExecutionAndPublication);
        private Lazy<SomeDataObject> dataB = new Lazy<SomeDataObject>(() => DefaultData, LazyThreadSafetyMode.ExecutionAndPublication);
        public SomeDataObject DataA
        {
            get
            {
                return dataA.Value;
            }
            set
            {
                dataA = new Lazy<SomeDataObject>(() => value, LazyThreadSafetyMode.ExecutionAndPublication);
                dataB = new Lazy<SomeDataObject>(GetDataB, LazyThreadSafetyMode.ExecutionAndPublication);
            }
        }
        public SomeDataObject DataB
        {
            get
            {
                return dataB.Value;
            }
            set
            {
                dataB = new Lazy<SomeDataObject>(() => value, LazyThreadSafetyMode.ExecutionAndPublication);
                dataA = new Lazy<SomeDataObject>(GetDataA, LazyThreadSafetyMode.ExecutionAndPublication);
            }
        }
        private SomeDataObject GetDataA()
        {
            if (DefaultData == dataB.Value)
            {
                return null;
            }
            ////////////////////////////////
            // Calculate dataA from dataB //
            // and return it.             //
            ////////////////////////////////
        }
        private SomeDataObject GetDataB()
        {
            if (DefaultData == dataA.Value)
            {
                return null;
            }
            ////////////////////////////////
            // Calculate dataA from dataB //
            // and return it.             //
            ////////////////////////////////
        }
