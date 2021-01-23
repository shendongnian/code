        public static SynchronizationContext SynchronizationContext {
            get {
                if (SynchronizationContext.Current == null) {
                    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
                }
                return SynchronizationContext.Current;
            }
        }
