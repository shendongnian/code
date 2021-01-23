    class Bullet: Collidable
    {
        public Bullet()
        {
            collisionTypes.Add(typeof(Player), HandleBulletPlayerCollision);
            collisionTypes.Add(typeof(Bullet), HandleBulletBulletCollision);
        }
        private void HandleBulletPlayerCollision(Collidable with)
        {
            Console.WriteLine("Bullet collided with {0}", with.ToString());
        }
        private void HandleBulletBulletCollision(Collidable with)
        {
            Console.WriteLine("Bullet collided with {0}.", with.ToString());
        }
    }
