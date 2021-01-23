    class CoreTransaction
    {
        private static List<WeakReference> allCoreTransactions = new List<WeakReference>();
        public CoreTransaction()
        {
            allCoreTransactions.Add(new WeakReference(this));
        }
        public static void TrimAll()
        {
            foreach (WeakReference reference in allCoreTransactions)
            {
                if (reference.IsAlive)
                {
                    ((CoreTransaction)reference.Target).Trim();
                }
            }
        }
    }
