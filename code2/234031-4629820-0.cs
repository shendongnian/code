    public abstract class Enemy
    {
        virtual public int KillScore
        {
            get { return 0; }
        }
    }
    
    public class Martian : Enemy
    {
        public override int KillScore
        {
            get { return 10; }
        }
    }
    
    // All the other classes here
    public class Destoyer : Enemy
    {
        public override int KillScore
        {
            get { return 200; }
        }
    }
