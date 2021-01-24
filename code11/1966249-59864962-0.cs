    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public class Program
    {
        public static void Run()
        {
            Expression<Func<int, bool>> isOdd = number => (number % 2) == 0;
            Expression<Func<string, int>> parseTextToNumber = text => Convert.ToInt32(text);
            var visitor = new ReplaceExpressionVisitor(isOdd.Parameters[0], parseTextToNumber.Body);
            var result = Expression.Lambda(visitor.Visit(isOdd.Body), parseTextToNumber.Parameters);
            Expression<Func<string, bool>> textRepresentsOddNumber = result as dynamic;
            //test:
            var code = textRepresentsOddNumber.Compile();
            Console.WriteLine(code.DynamicInvoke("0"));//writes false
            Console.WriteLine(code.DynamicInvoke("1"));//writes true
        }
    }
    private class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;
        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }
        public override Expression Visit(Expression node)
        {
            if (node == _oldValue)
                return _newValue;
            return base.Visit(node);
        }
    }
