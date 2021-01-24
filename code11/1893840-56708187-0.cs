    public abstract class Enemy
    {
        public bool CanJump { get; set; } = false;
        public bool CanRoar { get; set; } = false;
        public bool CanAttack { get; set; } = false;
        public virtual void Attack()
        {
            Console.WriteLine("This is an enemy");
            if (CanJump)
            {
                Console.WriteLine("Enemy is jumping");
            }
            if (CanRoar)
            {
                Console.WriteLine("Enemy is roaring");
            }
            if (CanAttack)
            {
                Console.WriteLine("Enemy is attacking");
            }
        }
    }
    public class Enemy1 : Enemy
    {
        public Enemy1()
        {
            CanJump = true;
            CanRoar = true;
        }
    }
    public class Enemy2 : Enemy
    {
        public Enemy2()
        {
            CanRoar = true;
            CanAttack = true;
        }
    }
    public class Enemy3 : Enemy
    {
        public Enemy3()
        {
            CanRoar = true;
            CanAttack = true;
        }
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("Custom thing");
        }
    }
