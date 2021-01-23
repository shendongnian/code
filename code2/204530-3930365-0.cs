    public abstract class ArithmeticOperator
    {
        public static readonly ArithmeticOperator Plus = new PlusOperator();
        public static readonly ArithmeticOperator Minus = new MinusOperator();
        public abstract int Apply(int x, int y);
        private ArithmeticOperator() {}
        private class PlusOperator : ArithmeticOperator
        {
            public override int Apply(int x, int y)
            {
                return x + y;
            }
        }
        private class MinusOperator : ArithmeticOperator
        {
            public override int Apply(int x, int y)
            {
                return x - y;
            }
        }
    }
