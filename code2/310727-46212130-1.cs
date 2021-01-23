     public static Func<T, bool> CompileRuleExpression<T>(RuleExpression ruleExpression)
        {
            //Input parameter
            var genericType = Expression.Parameter(typeof(T));
            var binaryExpression = RuleExpressionToOneExpression<T>(ruleExpression, genericType);
            var lambdaFunc = Expression.Lambda<Func<T, bool>>(binaryExpression, genericType);
            return lambdaFunc.Compile();
        }
        private static Expression RuleExpressionToOneExpression<T>(RuleExpression ruleExpression, ParameterExpression genericType)
        {
            if (ruleExpression == null)
            {
                throw new ArgumentNullException();
            }
            Expression finalExpression;
            //check if node is leaf
            if (ruleExpression.NodeOperator == NodeOperator.Leaf)
            {
                return RuleToExpression<T>(ruleExpression.Rule, genericType);
            }
            //check if node is NodeOperator.And
            if (ruleExpression.NodeOperator.Equals(NodeOperator.And))
            {
                finalExpression = Expression.Constant(true);
                ruleExpression.Expressions.ForEach(expression =>
                {
                    finalExpression = Expression.AndAlso(finalExpression, expression.NodeOperator.Equals(NodeOperator.Leaf) ? 
                        RuleToExpression<T>(expression.Rule, genericType) :
                        RuleExpressionToOneExpression<T>(expression, genericType));
                });
                return finalExpression;
            }
            //check if node is NodeOperator.Or
            else
            {
                finalExpression = Expression.Constant(false);
                ruleExpression.Expressions.ForEach(expression =>
                {
                    finalExpression = Expression.Or(finalExpression, expression.NodeOperator.Equals(NodeOperator.Leaf) ?
                        RuleToExpression<T>(expression.Rule, genericType) :
                        RuleExpressionToOneExpression<T>(expression, genericType));
                });
                return finalExpression;
            }      
        }      
        public static BinaryExpression RuleToExpression<T>(Rule rule, ParameterExpression genericType)
        {
            try
            {
                Expression value = null;
                //Get Comparison property
                var key = Expression.Property(genericType, rule.ComparisonPredicate);
                Type propertyType = typeof(T).GetProperty(rule.ComparisonPredicate).PropertyType;
                //convert case is it DateTimeOffset property
                if (propertyType == typeof(DateTimeOffset))
                {
                    var converter = TypeDescriptor.GetConverter(propertyType);
                    value = Expression.Constant((DateTimeOffset)converter.ConvertFromString(rule.ComparisonValue));
                }
                else
                {
                    value = Expression.Constant(Convert.ChangeType(rule.ComparisonValue, propertyType));
                }
                BinaryExpression binaryExpression = Expression.MakeBinary(rule.ComparisonOperator, key, value);
                return binaryExpression;
            }
            catch (FormatException)
            {
                throw new Exception("Exception in RuleToExpression trying to convert rule Comparison Value");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
