    abstract class BaseEnemy {
        public virtual void Attack() {
            AttackIdentify();
            AttackSignal();
            AttackAttack();
        }
    
        protected virtual void AttackIdentify() {
            Console.WriteLine("This is an enemy");
        }
    
        protected virtual void AttackSignal() {
            Console.WriteLine("Enemy is jumping");
        }
    
        protected virtual void AttackAttack() {
            Console.WriteLine("Enemy is attacking");
        }
    }
    
    class Enemy1 : BaseEnemy {
        protected override void AttackIdentify() {
            Console.WriteLine("This is an enemy 1");
        }
    }
    
    class Enemy2 : BaseEnemy {
    }
    
    class Enemy3 : BaseEnemy {
        protected override void AttackIdentify() {
            Console.WriteLine("This is an enemy 3");
        }
    }
    
    //Let's say this enemy is not capable of jumping, so we want to remove the code that says enemy is jumping.
    class Enemy4 : BaseEnemy {
        protected override void AttackSignal() { }
    }
    
    //Let's say this is the boss and instead of jumping, it will roar.
    //So we want to change the code that says enemy is jumping to enemy is roaring.
    class Enemy5 : BaseEnemy {
        protected override void AttackSignal() {
            Console.WriteLine("Enemy is roaring");
        }
    }
