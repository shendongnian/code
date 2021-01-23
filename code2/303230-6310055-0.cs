    abstract class Animal<T> where T : Animal<T>
    {
        public abstract void GetFriendly(T t);
    }
    class Cat : Animal<Cat>
    {
        public override void GetFriendly(Cat cat) {}
    }
