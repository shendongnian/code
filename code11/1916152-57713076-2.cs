    public class Stove
    {
        public void CookFood() { }
    }
    public class Chef
    {
        public void MakeFood()
        {
            var stove = new Stove();
            stove.CookFood();
        } 
    }
    public class Parent
    {
        public void FeedChildren()
        {
            var stove = new Stove();
            stove.CookFood();
        }
    }
