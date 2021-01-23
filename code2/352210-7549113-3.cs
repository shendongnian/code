    abstract class Collidable
    {
        public Sprite Sprite { get; protected set;  }
        public int Damage { get; protected set; }
        protected delegate void CollisionAction(Collidable with);
        protected Dictionary<Type, CollisionAction> collisionTypes = new Dictionary<Type, CollisionAction>();
        public void HandleCollision(Collidable with)
        {
            Type collisionTargetType = with.GetType();
            CollisionAction action;
            bool keyFound = collisionTypes.TryGetValue(collisionTargetType, out action);
            if (keyFound)
            {
                action(with);
            }
        }
    }
