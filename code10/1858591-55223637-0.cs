    public class Offer1
    {
        internal static readonly Guid ID = new Guid(...);
        private Guid _id => ID;
        // or
        private readonly Guid _id = ID;
    }
