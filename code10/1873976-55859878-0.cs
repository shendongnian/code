    // Really, don't do this.
    public class ItemNotFoundByIdException<T> : Exception
    {
        public ItemNotFoundByIdException()
        :base($"{typeof(T).Name} not found by ID.") { }
    }
