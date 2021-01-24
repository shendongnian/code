    interface ICollisionHandler<T>
        where T : IGameObject
    {
        void HandleCollision(IGameObject object1, T object2);
    }
    
    class GenericCollision: ICollisionHandler<IEnemy>
    {
        public void HandleCollision(IGameObject foo, IEnemy bar)
        {
            bar.TakeDamage();            
        }
    }
