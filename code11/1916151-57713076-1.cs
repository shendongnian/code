    public interface IStove
    {
        void CookFood();
    }
    public class Chef
    {
        private readonly IStove _stove;
        public Chef(IStove stove)
        {
            _stove = stove;
        }
        public void FeedChildren()
        {
            _stove.CookFood();
        } 
    }
    public class Parent
    {
        private readonly IStove _stove;
        public Parent(IStove stove)
        {
            _stove = stove;
        }
        public void MakeFood()
        {
            _stove.CookFood();
        }
    }
