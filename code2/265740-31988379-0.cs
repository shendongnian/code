    public interface IPersonId
    {
        int Value { get; }
    }
    public static class PersonId
    {
        public static IPersonId Create(int id)
        {
            return new Id(id);
        }
        internal struct Id : IPersonId
        {
            public Id(int value)
            {
                this.Value = value;
            }
            public int Value { get; }
            /* Implement equality comparer here */
        }
    }
