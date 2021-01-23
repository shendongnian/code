    class Cat : Animal 
    {
        public override void MakeFriends(IEnumerable<Cat> newFriends) {}
    }
    class Tiger: Animal
    {
        // illegal!
        public override void MakeFriends(IEnumerable<Cat> newFriends) { ... }
    }
