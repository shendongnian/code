    class Player : Collidable
    {
        public Player()
        {
            collisionTypes.Add(typeof(Bullet), HandlePlayerBulletCollision);
            collisionTypes.Add(typeof(Player), HandlePlayerPlayerCollision);
        }
        private void HandlePlayerBulletCollision(Collidable with)
        {
            Console.WriteLine("Player collided with {0}.", with.ToString());
        }
        private void HandlePlayerPlayerCollision(Collidable with)
        {
            Console.WriteLine("Player collided with {0}.", with.ToString());
        }
    }
