    abstract class Animal<T> where T : Animal<T>
    {
        public abstract void MakeFriends(T newFriend);
    }
    class Cat : Animal<Cat>
    {
        public override void MakeFriends(Cat newFriend){ ... }
    }
