    using System;
    using System.Linq.Expressions;
    
    namespace ArrayOfReferences
    {
        public class InitializeMultipleVariables
        {
            int v1;
            int v2;
            int v3;
            int v4;
    
            public void InitializeAll()
            {
                Initialize(
                    () => v1, 
                    () => v2, 
                    () => v3, 
                    () => v4);
            }
    
            public void Initialize(params Expression<Func<int>>[] intExpressions)
            {
                for (int i = 0; i < intExpressions.Length; i++)
                {
                    var expr = intExpressions[i].Body as System.Linq.Expressions.MemberExpression;                
                    var fieldInfo = this.GetType().GetField(expr.Member.Name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    fieldInfo.SetValue(this, i);
                }
            }
        }
    }
