    public interface IHasId
    {
        int GetId();
    }
    class Test : IHasId
    {
        public static int id = 1;
        public int GetId()
        {
            return id;
        }
    }
    public int IncrementId<T>(T item) where T : IHasId
    {
        return item.GetId() + 1;
    }
