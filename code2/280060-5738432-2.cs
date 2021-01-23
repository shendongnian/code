    abstract class Operation
    {
        public abstract decimal Apply(decimal value);
        public abstract decimal Unapply(decimal value);
    }
    class CompoundInterest : Operation
    {
        public CompoundInterest(decimal percent)
        {
            this.percent = percent;
        }
        public override decimal Apply(decimal value)
        {
            return value * (1m + percent/100m);
        }
        public override decimal Unapply(decimal value)
        {
            return value / (1m + percent/100m);
        }
    }
    class NoncompoundInterest : Operation { ... }
    class Add : Operation { ... }
    class Subtract : Operation { ... }
