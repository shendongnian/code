    public class Game
    {
    
        public class GameObject
        {
            internal float[] position;
    
        }
    
        static public void Destroy(GameObject go)
        {
            // some object destruction
        }
    
        public class Gem : GameObject
        {
            // inherits position
        }
    
        public class Character : GameObject
        {
            // inherits position
            internal int health;
        }
    
        public class Enemy : Character
        {
            // inherits position and health
            public void OnCollision(GameObject other)
            {
                if (other is Player)
                {
                    health--;
                    if (health==0)
                    {
                        Destroy(this);
                    }
                }
            }
        }
    
        [System.Serializable]
        public class Player : Character
        {
            // inherits position and health
            // don't expose your internals
            // and probably should be properties.. but I don't know if they work with the serializer
            internal int level;
            internal int money;
    
            public void OnCollision(GameObject other)
            {
                if (other is Gem)
                {
                    Destroy(other);
                    money++;
                }
                else if (other is Enemy)
                {
                    health--;
                    if (health == 0)
                    {
                        //game over;
                    }
                }
            }
        }
    }
