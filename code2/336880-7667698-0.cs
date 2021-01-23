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
    }
    public class NumericAddExpression : NumericBinaryExpression
    {
        public NumericAddExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
    }
    public class NumericSubtractExpression : NumericBinaryExpression
    {
        public NumericSubtractExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
    }
    public class NumericMultiplyExpression : NumericBinaryExpression
    {
        public NumericMultiplyExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
    }
    public class NumericDivideExpression : NumericBinaryExpression
    {
        public NumericDivideExpression(NumericExpression lhs, NumericExpression rhs)
            : base(lhs, rhs)
        {
        }
    }
    public class NumericReferenceExpression : NumericExpression
    {
        public string Symbol { get; private set; }
        public NumericReferenceExpression(string symbol)
        {
            Symbol = symbol;
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
    }
