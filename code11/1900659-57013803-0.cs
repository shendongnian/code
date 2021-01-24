    public static class IterationExtensions {
        public static bool Active(this Iteration iteration)
        {
            return DateTime.Now.Date >= iteration.Start.Date && DateTime.Now.Date <= iteration.End.Date;
        }
    }
