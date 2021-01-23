    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace WindowsFormsApplication1
    {
        internal static class Program
        {
            [STAThread]
            private static void Main()
            {
                var calculator = new Calculator();
    
                //// DivideByZero - the result should be -1
                var data1 = new DataInfo { A = 10, B = 0, C = 1 };
                Expression<Func<DataInfo, decimal?>> expression1 = x => x.A / x.B + x.C;
                var result1 = calculator.Calcul(data1, expression1, "N0");
    
                //// Negative 1 - the result should be -
                var data2 = new DataInfo { A = 10, B = 5, C = -1 };
                Expression<Func<DataInfo, decimal?>> expression2 = x => x.A / x.B + x.C;
                var result2 = calculator.Calcul(data2, expression2, "N0");
    
                //// Negative 2 - the result should be C
                var data3 = new DataInfo { A = 10, B = 5, C = -2 };
                Expression<Func<DataInfo, decimal?>> expression3 = x => x.A / x.B + x.C;
                var result3 = calculator.Calcul(data3, expression3, "N0");
    
                //// the result should be 3
                var data4 = new DataInfo { A = 10, B = 5, C = 1 };
                Expression<Func<DataInfo, decimal?>> expression4 = x => x.A / x.B + x.C;
                var result4 = calculator.Calcul(data4, expression4, "N0");
    
                //// DivideByZero - the result should be -1
                var data5 = new List<DataInfo> {
                                        new DataInfo {A = 10, B = 0, C = 1},
                                        new DataInfo {A = 10, B = 0, C = 1}
                            };
    
                Expression<Func<IEnumerable<DataInfo>, decimal?>> expression5 = x => x.Sum(y => y.A) / x.Sum(y => y.B) + x.Sum(y => y.C);
                var result5 = calculator.Calcul(data5, expression5, "N0");
    
                //// the result should be 4
                var data6 = new List<DataInfo> {
                                        new DataInfo {A = 10, B = 5, C = 1},
                                        new DataInfo {A = 10, B = 5, C = 1}
                            };
    
                Expression<Func<IEnumerable<DataInfo>, decimal?>> expression6 = x => x.Sum(y => y.A) / x.Sum(y => y.B) + x.Sum(y => y.C);
                var result6 = calculator.Calcul(data6, expression6, "N0");
    
            }
        }
    
        public class Calculator
        {
            public string Calcul<T>(T data, LambdaExpression query, string format)
            {
                query = (LambdaExpression)ExpressionPreProcessor.PreProcessor(data, query);
    
                var rulesCheckerResult = RulesChecker.Check(data, query);
    
                if (rulesCheckerResult.HasManquante)
                {
                    return TypeDonnee.Manquante.ReportValue;
                }
    
                if (rulesCheckerResult.HasDivisionParZero)
                {
                    return TypeDonnee.DivisionParZero.ReportValue;
                }
    
                if (rulesCheckerResult.HasNonDiffusable)
                {
                    return TypeDonnee.NonDiffusable.ReportValue;
                }
    
                if (rulesCheckerResult.HasConfidentielle)
                {
                    return TypeDonnee.Confidentielle.ReportValue;
                }
    
                Delegate lambda = query.Compile();
                decimal? result = (decimal?)lambda.DynamicInvoke(data);
    
                return result != null
                    ? result.Value.ToString(format)
                    : TypeDonnee.Manquante.ReportValue;
            }
        }
    
        internal class ExpressionPreProcessor : ExpressionVisitor
        {
            private readonly object _source;
    
            public static Expression PreProcessor(object source, Expression expression)
            {
                if (!IsValidSource(source))
                {
                    return expression;
                }
    
                var visitor = new ExpressionPreProcessor(source);
    
                return visitor.Visit(expression);
            }
    
            private static bool IsValidSource(object source)
            {
                if (source == null)
                {
                    return false;
                }
    
                var type = source.GetType();
    
                return type.IsGenericType && type.GetInterface("IEnumerable") != null;
            }
    
            public ExpressionPreProcessor(object source)
            {
                this._source = source;
            }
    
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.DeclaringType == typeof(Enumerable) && node.Arguments.Count == 2)
                {
    
                    switch (node.Method.Name)
                    {
                        case "Count":
                        case "Min":
                        case "Max":
                        case "Sum":
                        case "Average":
                            var lambda = node.Arguments[1] as LambdaExpression;
                            var lambaDelegate = lambda.Compile();
                            var value = node.Method.Invoke(null, new object[] { this._source, lambaDelegate });
    
                            return Expression.Constant(value);
                    }
                }
    
                return base.VisitMethodCall(node);
            }
        }
    
        internal class RulesChecker : ExpressionVisitor
        {
            private readonly object data;
            private bool hasConfidentielle = false;
            private bool hasNonDiffusable = false;
            private bool hasDivisionParZero = false;
            private bool hasManquante = false;
    
            public RulesChecker(object data)
            {
                this.data = data;
            }
    
            public static RulesCheckerResult Check(object data, Expression expression)
            {
                var visitor = new RulesChecker(data);
                visitor.Visit(expression);
    
                return new RulesCheckerResult(
                    visitor.hasConfidentielle,
                    visitor.hasNonDiffusable,
                    visitor.hasDivisionParZero,
                    visitor.hasManquante);
            }
    
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (!this.hasDivisionParZero && node.NodeType == ExpressionType.Divide)
                {
                    if (node.Right.NodeType == ExpressionType.MemberAccess)
                    {
                        var rightMemeberExpression = (MemberExpression)node.Right;
                        var propertyInfo = (PropertyInfo)rightMemeberExpression.Member;
                        var value = Convert.ToInt32(propertyInfo.GetValue(this.data, null));
    
                        this.hasDivisionParZero = value == 0;
                    }
    
                    if (node.Right.NodeType == ExpressionType.Constant)
                    {
                        var rightConstantExpression = (ConstantExpression)node.Right;
                        var value = Convert.ToInt32(rightConstantExpression.Value);
    
                        this.hasDivisionParZero = value == 0;
                    }
    
                }
    
                return base.VisitBinary(node);
            }
    
            protected override Expression VisitConstant(ConstantExpression node)
            {
                this.CheckValue(this.ConvertToNullableInt(node.Value));
    
                return base.VisitConstant(node);
            }
    
            protected override Expression VisitMember(MemberExpression node)
            {
                if (!this.hasConfidentielle || !this.hasNonDiffusable || !this.hasManquante)
                {
                    var propertyInfo = (PropertyInfo)node.Member;
                    var value = propertyInfo.GetValue(this.data, null);
    
                    this.CheckValue(this.ConvertToNullableInt(value));
                }
    
                return base.VisitMember(node);
            }
    
            private void CheckValue(int? value)
            {
                if (!this.hasManquante)
                {
                    this.hasManquante = value == TypeDonnee.Manquante.BdValue;
                }
    
                if (!this.hasConfidentielle)
                {
                    this.hasConfidentielle = value == TypeDonnee.Confidentielle.BdValue;
                }
    
                if (!this.hasNonDiffusable)
                {
                    this.hasNonDiffusable = value == TypeDonnee.NonDiffusable.BdValue;
                }
            }
    
            private int? ConvertToNullableInt(object value)
            {
                // MTO.Framework.Common.Convert.To<int?>(value);
                return (int?)value;
            }
        }
    
        class RulesCheckerResult
        {
            public bool HasConfidentielle { get; private set; }
            public bool HasNonDiffusable { get; private set; }
            public bool HasDivisionParZero { get; private set; }
            public bool HasManquante { get; private set; }
    
            public RulesCheckerResult(bool hasConfidentielle, bool hasNonDiffusable, bool hasDivisionParZero, bool hasManquante)
            {
                this.HasConfidentielle = hasConfidentielle;
                this.HasNonDiffusable = hasNonDiffusable;
                this.HasDivisionParZero = hasDivisionParZero;
                this.HasManquante = hasManquante;
            }
        }
    
        class TypeDonnee
        {
            public static readonly TypeValues Manquante = new TypeValues(null, "-");
            public static readonly TypeValues Confidentielle = new TypeValues(-1, "-");
            public static readonly TypeValues NonDiffusable = new TypeValues(-2, "C");
            public static readonly TypeValues DivisionParZero = new TypeValues(0, "-1");
        }
    
        class TypeValues
        {
            public int? BdValue { get; set; }
            public string ReportValue { get; set; }
    
            public TypeValues(int? bdValue, string reportValue)
            {
                this.BdValue = bdValue;
                this.ReportValue = reportValue;
            }
        }
    
        class DataInfo
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
        }
    }
