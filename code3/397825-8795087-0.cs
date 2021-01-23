    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var value1 = 1;
                var value2 = 2;
                var value3 = new { MyValue = 3 };
                var data = new DataInfo { A = 10, B = 1, C = -1 };
    
                Expression<Func<DataInfo, decimal?>> expression = x => x.A / (x.B + x.C) + (value1 + value2) + value3.MyValue;
    
                // create a list of variables that will be used when evaluating the expression
                var variables = new Dictionary<Type, object>();
    
                // add the root object
                variables.Add(data.GetType(), data);
    
                // find variables that are referenced in the expression
                var finder = new VariablesFinder(variables);
                finder.Visit(expression);
    
                // replace variables with ConstantExpressions
                var visitor = new VariableReplacer(variables);
                var newExpression = visitor.Visit(expression);
    
                var rulesChecker = new RulesChecker();
                var checkedExpression = rulesChecker.Visit(newExpression);
            }
        }
    
        internal class RulesChecker : ExpressionVisitor
        {
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (node.NodeType == ExpressionType.Divide)
                {
                    var rightBinaryExpression = node.Right as BinaryExpression;
    
                    if (rightBinaryExpression != null)
                    {
                        node = node.Update(node.Left, node.Conversion, this.Execute(rightBinaryExpression));
                    }
                }
    
                return base.VisitBinary(node);
            }
    
            private Expression Execute(BinaryExpression node)
            {
                var lambda = Expression.Lambda(node);
                dynamic func = lambda.Compile();
                var result = func();
    
                return Expression.Constant(result, result.GetType());
            }
        }
        
        internal class VariableReplacer : ExpressionVisitor
        {
            private readonly Dictionary<Type, object> _variables;
    
            public VariableReplacer(Dictionary<Type, object> variables)
            {
                this._variables = variables;
            }
    
            protected override Expression VisitMember(MemberExpression node)
            {
                return this.HandleProperty(node) ??
                       this.HandleField(node) ??
                       node;
            }
    
            private Expression HandleField(MemberExpression memberExpression)
            {
                var fieldInfo = memberExpression.Member as FieldInfo;
    
                if (fieldInfo != null)
                {
                    var value = fieldInfo.GetValue(this.GetVarialbe(fieldInfo));
    
                    return Expression.Constant(value, fieldInfo.FieldType);
                }
    
                return null;
            }
    
            private Expression HandleProperty(MemberExpression memberExpression)
            {
                var propertyInfo = memberExpression.Member as PropertyInfo;
    
                if (propertyInfo != null)
                {
                    var value = propertyInfo.GetValue(this.GetVarialbe(propertyInfo), null);
    
                    return Expression.Constant(value, propertyInfo.PropertyType);
                }
    
                return null;
            }
    
            private object GetVarialbe(MemberInfo memberInfo)
            {
                return this._variables[memberInfo.DeclaringType];
            }
        }
    
        internal class VariablesFinder : ExpressionVisitor
        {
            private readonly Dictionary<Type, object> _variables;
    
            public VariablesFinder(Dictionary<Type, object> variables)
            {
                this._variables = variables;
            }
    
            protected override Expression VisitConstant(ConstantExpression node)
            {
                this.AddVariable(node.Type, node.Value);
    
                return base.VisitConstant(node);
            }
    
            private void AddVariable(Type type, object value)
            {
                if (type.IsPrimitive)
                {
                    return;
                }
    
                if (this._variables.Keys.Contains(type))
                {
                    return;
                }
    
                this._variables.Add(type, value);
    
                var fields = type.GetFields().Where(x => !x.FieldType.IsPrimitive).ToList();
    
                foreach (var field in fields)
                {
                    this.AddVariable(field.FieldType, field.GetValue(value));
                }
            }
        }
    
        class DataInfo
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public int D;
        }
    }
