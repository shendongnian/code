    // interface to a king
    public interface IKing
    {
        Result Get();
    }
    // main abstract class
    public abstract class King : IKing
    {
        public abstract Result Get();
    }
    // main abstract result
    public abstract class Result
    {
        private int _Type;
        public int Type { get { return _Type; } set { _Type = value; } }
    }
    // KingA result
    public class ResultA : Result
    {
    }
    // KingB result
    public class ResultB : Result
    {
    }
    // concrete implementations
    public class KingA : King
    {
        public override Result Get()
        {
            return new ResultA();
        }
    }
    public class KingB : King
    {
        public override Result Get()
        {
            return new ResultB();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IKing ka = new KingA();
            IKing kb = new KingB();
            Result ra = ka.Get();
            Result rb = kb.Get();
            if (ra is ResultA)
            {
                Console.WriteLine("A ok!");
            }
            if (rb is ResultB)
            {
                Console.WriteLine("B ok!");
            }
        }
    }
