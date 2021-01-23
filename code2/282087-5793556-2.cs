    public static class FlagsExtensions
    {
        public static void AddTo(this MyFlags add, ref MyFlags addTo)
        {
             addTo = addTo | add;
        }
    }
    MyFlags.Coke.AddTo(ref flags);
