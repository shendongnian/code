    class Program
    {
        static void Main(string[] args)
        {
            MilesCustomer customer = new MilesCustomer();
            ICustomerVisitor<int> visitor = new MilesCalculation(10);
            var miles = customer.Visit(visitor);
            visitor = new RewardsCalucation(100);
            var rewards = customer.Visit(visitor);
        }
    }
    public interface ICustomerVisitor<T>
    {
        T Visit(SimpleCustomer cusomter);
        T Visit(RewardsCustomer cusomter);
        T Visit(MilesCustomer cusomter);
    }
    public abstract class Customer
    {
        public Customer()
        {
            TotalMoneySpent = 10;
        }
        public int TotalMoneySpent { get; private set; }
        public abstract T Visit<T>(ICustomerVisitor<T> visitor);
        public virtual void Display()
        {
            Console.WriteLine("I am simple customer");
        }
    }
    public class RewardsCalucation : ICustomerVisitor<int>
    {
        private int _rewardsPerDollar;
        public RewardsCalucation(int rewardsPerDollar) => _rewardsPerDollar = rewardsPerDollar;
        public int Visit(SimpleCustomer cusomter)
        {
            return 0;
        }
        public int Visit(RewardsCustomer cusomter)
        {
            return cusomter.TotalMoneySpent * _rewardsPerDollar;
        }
        public int Visit(MilesCustomer cusomter)
        {
            return 0;
        }
    }
    public class MilesCalculation : ICustomerVisitor<int>
    {
        private int _milesPerDollar;
        public MilesCalculation(int milesPerDollar) => _milesPerDollar = milesPerDollar;
        public int Visit(SimpleCustomer cusomter)
        {
            return 0;
        }
        public int Visit(RewardsCustomer cusomter)
        {
            return 0;
        }
        public int Visit(MilesCustomer cusomter)
        {
            return cusomter.TotalMoneySpent * _milesPerDollar;
        }
    }
    public class SimpleCustomer : Customer
    {
        public override T Visit<T>(ICustomerVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    public class RewardsCustomer : Customer
    {
        public override T Visit<T>(ICustomerVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    public class MilesCustomer : Customer
    {
        public override T Visit<T>(ICustomerVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
