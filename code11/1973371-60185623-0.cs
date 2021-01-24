    class EnemeyFactory
    {
        // diffrence setting 
        public Enemy SpawnA(int enemyID ...) { ... }
        public Enemy SpawnB(int enemyID)
        {
             Model m = findM(enemyID);
             AIBehavior b = findB(enemyID);
            
             g = new GameObject();
             Enemy e = g.AddCompoent<Enemy>();
             g.AddCompoent<PlayerMovemt>();
             g.AddCompoent<ModelHandle>().Init(m);
             g.AddCompoent<AIBehavior>().Init(b);
             int hp = 1000;
             g.AddCompoent<Health>().Init(hp);
             //...Add what you want.
             return e;
        }
    } 
