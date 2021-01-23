    internal class ImplementationDetail
    {
        private static readonly object lockme = new object();
        public static void DoDatabaseQuery(whatever)
        {
            lock(lockme)
                 ReallyDoQuery(whatever);
        }
    }
