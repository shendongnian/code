    public abstract class BaseExpression
    {
        // Maybe a Compile() method here?
    }
    public class NumericExpression : BaseExpression
    {
        public static NumericExpression operator +(NumericExpression lhs, NumericExpression rhs)
        {
            return new NumericAddExpression(lhs, rhs);
        }
        public static NumericExpression operator -(NumericExpression lhs, NumericExpression rhs)
        {
            return new NumericSubtractExpression(lhs, rhs);
        }
        public static NumericExpression operator *(NumericExpression lhs, NumericExpression rhs)
        {
            return new NumericMultiplyExpression(lhs, rhs);
        }
        public static NumericExpression operator /(NumericExpression lhs, NumericExpression rhs)
        {
            return new NumericDivideExpression(lhs, rhs);
        }
        public static implicit operator NumericExpression(int value)
        {
            return new NumericConstantExpression(value);
        }
        public abstract int Evaluate(Dictionary<string,int> symbolTable);
        public abstract override string ToString();
    }
    public abstract class NumericBinaryExpression : NumericExpression
    {
        protected NumericExpression LHS { get; private set; }
        protected NumericExpression RHS { get; private set; }
        protected NumericBinaryExpression(NumericExpression lhs, NumericExpression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", LHS, Operator, RHS);
        }
    }
    public class NumericAddExpression : NumericBinaryExpression
    {
        protected override string Operator { get { return "+"; } }
        public NumericAddExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
        public override int Evaluate(Dictionary<string,int> symbolTable)
        {
            return LHS.Evaluate(symbolTable) + RHS.Evaluate(symbolTable);
        }
    }
    public class NumericSubtractExpression : NumericBinaryExpression
    {
        protected override string Operator { get { return "-"; } }
        public NumericSubtractExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
        public override int Evaluate(Dictionary<string, int> symbolTable)
        {
            return LHS.Evaluate(symbolTable) - RHS.Evaluate(symbolTable);
        }
    }
    public class NumericMultiplyExpression : NumericBinaryExpression
    {
        protected override string Operator { get { return "*"; } }
        public NumericMultiplyExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
        public override int Evaluate(Dictionary<string, int> symbolTable)
        {
            return LHS.Evaluate(symbolTable) * RHS.Evaluate(symbolTable);
        }
    }
    public class NumericDivideExpression : NumericBinaryExpression
    {
        protected override string Operator { get { return "/"; } }
        public NumericDivideExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
        public override int Evaluate(Dictionary<string, int> symbolTable)
        {
            return LHS.Evaluate(symbolTable) / RHS.Evaluate(symbolTable);
        }
    }
    public class NumericReferenceExpression : NumericExpression
    {
        public string Symbol { get; private set; }
        public NumericReferenceExpression(string symbol)
        {
            Symbol = symbol;
        }
        public override int Evaluate(Dictionary<string, int> symbolTable)
        {
            return symbolTable[Symbol];
        }
        public override string ToString()
        {
            return string.Format("Ref({0})", Symbol);
        }
    }
    public class StringConstantExpression : BaseExpression
    {
        public string Value { get; private set; }
        public StringConstantExpression(string value)
        {
            Value = value;
        }
        public static implicit operator StringConstantExpression(string value)
        {
            return new StringConstantExpression(value);
        }
    }
    public class NumericConstantExpression : NumericExpression
    {
        public int Value { get; private set; }
        public NumericConstantExpression(int value)
        {
            Value = value;
        }
        public override int Evaluate(Dictionary<string, int> symbolTable)
        {
            return Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
