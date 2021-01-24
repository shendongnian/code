    public class Egg
    {
        private Func<IBird> _createBird;
        public Egg(Func<IBird> createBird)
        {
            _createBird = createBird;
        }
    
        public IBird Hatch()
        {
            return _createBird();
        }
    }
