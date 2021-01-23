    abstract class Collidable
    {
        public Sprite Sprite { get; }
        public int Damage { get; }
        protected Dictionary<Type, Action<Collidable>> collisionTypes = new Dictionary<Type, Action<Collidable>>();
        public void HandleCollision(Collidable with)
        {
            Type collisionTargetType = with.GetType();
            Action<Collidable> action;
            bool keyFound = collisionTypes.TryGetValue(collisionTargetType, out action);
            if (keyFound)
            {
                action(with);
            }
        }
    }
