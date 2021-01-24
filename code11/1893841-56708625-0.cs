    abstract class BaseEnemy {
        public virtual void Attack() {
            AttackIdentify();
            AttackSignal();
            AttackAttack();
        }
    
        public virtual void AttackIdentify() {
            Console.WriteLine("This is an enemy");
        }
    
        public virtual void AttackSignal() {
            Console.WriteLine("Enemy is jumping");
        }
    
        public virtual void AttackAttack() {
            Console.WriteLine("Enemy is attacking");
        }
    }
    
    class Enemy1 : BaseEnemy {
        public override void AttackIdentify() {
            Console.WriteLine("This is an enemy 1");
        }
    }
    
    class Enemy2 : BaseEnemy {
    }
    
    class Enemy3 : BaseEnemy {
        public override void AttackIdentify() {
            Console.WriteLine("This is an enemy 3");
        }
    }
    
    //Let's say this enemy is not capable of jumping, so we want to remove the code that says enemy is jumping.
    class Enemy4 : BaseEnemy {
        public override void AttackSignal() { }
    }
    
    //Let's say this is the boss and instead of jumping, it will roar.
    //So we want to change the code that says enemy is jumping to enemy is roaring.
    class Enemy5 : BaseEnemy {
        public override void AttackSignal() {
            Console.WriteLine("Enemy is roaring");
        }
    }
