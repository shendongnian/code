    abstract class Animal<T> where T : Animal<T>
    {
        public abstract void MakeFriends(IEnumerable<T> newFriends);
    }
    class Cat : Animal<Cat>
    {
        public override void MakeFriends(IEnumerable<Cat> newFriends) { ... }
    }
