    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                // HasDivideByZero - the result should be -1
                int result1 = Calcul<DataInfo>(new DataInfo { A = 10, B = 0, C = 1 }, x => x.A / x.B + x.C);
                // HasNegative - the result should be 0
                int result2 = Calcul<DataInfo>(new DataInfo { A = 10, B = 5, C = -1 }, x => x.A / x.B + x.C);
                // the result should be 3
                int result3 = Calcul<DataInfo>(new DataInfo { A = 10, B = 5, C = 1 }, x => x.A / x.B + x.C);
            }
    
            static int Calcul<T>(T data, Expression<Func<T, int>> query)
            {
                if (NegativeValueChecker<T>.HasNegative(data, query))
                {
                    return 0;
                }
    
                if (DivideByZeroChecker<T>.HasDivideByZero(data, query))
                {
                    return -1;
                }
    
                return query.Compile().Invoke(data);
            }
        }
    
        class DivideByZeroChecker<T> : ExpressionVisitor
        {
            private readonly T _data;
            private bool _hasDivideByZero;
    
            public static bool HasDivideByZero(T data, Expression expression)
            {
                var visitor = new DivideByZeroChecker<T>(data);
                visitor.Visit(expression);
    
                return visitor._hasDivideByZero;
            }
    
            public DivideByZeroChecker(T data)
            {
                this._data = data;
            }
    
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (!this._hasDivideByZero && node.NodeType == ExpressionType.Divide)
                {
                    var rightMemeberExpression = (MemberExpression)node.Right;
                    var propertyInfo = (PropertyInfo)rightMemeberExpression.Member;
                    var value = Convert.ToInt32(propertyInfo.GetValue(this._data, null));
                    this._hasDivideByZero = value == 0;
                }
    
                return base.VisitBinary(node);
            }
        }
    
        class NegativeValueChecker<T> : ExpressionVisitor
        {
            private readonly T _data;
            public bool _hasNegative;
    
            public static bool HasNegative(T data, Expression expression)
            {
                var visitor = new NegativeValueChecker<T>(data);
                visitor.Visit(expression);
    
                return visitor._hasNegative;
            }
    
            public NegativeValueChecker(T data)
            {
                this._data = data;
            }
    
            protected override Expression VisitMember(MemberExpression node)
            {
                if (!this._hasNegative)
                {
                    var propertyInfo = (PropertyInfo)node.Member;
                    var value = Convert.ToInt32(propertyInfo.GetValue(this._data, null));
                    this._hasNegative = value < 0;
                }
    
                return base.VisitMember(node);
            }
        }
    
        class DataInfo
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
        }
    }
