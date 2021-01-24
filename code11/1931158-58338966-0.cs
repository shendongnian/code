    namespace RuleEngine
    {
        public class PropertyDescriptor
        {
            public string PropertyName { get; }
            public Type PropertyType { get; }
            public PropertyDescriptor(string propertyName, Type propertyType)
            {
                PropertyName = propertyName;
                PropertyType = propertyType;
            }
        }
        public class RuleEngine
        {
            public static IEnumerable<RuleOutput> RunRule(IEnumerable<RuleCondition> rules, object targetEntity)
            {
                Type entityType = targetEntity.GetType();
                IEnumerable<RuleOutput> ruleOutput = null;
                foreach (var rule in rules)
                {
                    var ruleDetails = rule.RuleConditionDetails;
                    rule.RuleConditionDetails.ForEach((item) =>
                    {
                        item.ConditionOperatorToApply = GetExpressionOperator(item.ConditionOperator);
                    });
                    var compiledRules = CompileRule(rule.RuleConditionDetails, entityType);
                    var foundMatchingRule = compiledRules.All(ruleTemp => ruleTemp(targetEntity));
                    if (foundMatchingRule)
                    {
                        ruleOutput = rule.RuleConditionOutput;
                        break;
                    }
                }
                return ruleOutput;
            }
            private static List<Func<object, bool>> CompileRule(List<RuleConditionDetails> ruleConditionDetailsList,
                Type entityType)
            {
                var compiledRules = new List<Func<object, bool>>();
                ruleConditionDetailsList.ForEach(ruleConditionDetails =>
                {
                    var parameterExpression = Expression.Parameter(typeof(object));
                    var entityExpression = Expression.Convert(parameterExpression, entityType);
                    var binaryExpression = BuildBinaryExpression(ruleConditionDetails, entityExpression, entityType);
                    compiledRules.Add(
                        Expression.Lambda<Func<object, bool>>(binaryExpression, parameterExpression).Compile());
                });
                return compiledRules;
            }
            private static Expression BuildBinaryExpression(RuleConditionDetails ruleConditionDetails,
                Expression parameterExpression, Type entityType)
            {
                Expression expression = null;
                var leftOperand = MemberExpression.Property(parameterExpression, ruleConditionDetails.RuleParameter);
                ExpressionType expressionType;
                Type operandType = null;
                MethodInfo methodInfo = null;
                if (ExpressionType.TryParse(ruleConditionDetails.ConditionOperatorToApply, out expressionType))
                {
                    operandType = entityType.GetProperty(ruleConditionDetails.RuleParameter).PropertyType;
                    var rightOperand =
                        Expression.Constant(Convert.ChangeType(ruleConditionDetails.ParameterValue, operandType));
                    expression = Expression.MakeBinary(expressionType, leftOperand, rightOperand);
                }
                else
                {
                    if (ruleConditionDetails.ConditionOperatorToApply == "Contains")
                    {
                        ruleConditionDetails.ParameterValue =
                            ruleConditionDetails.ParameterValue.ToString().Split(',').ToList();
                        operandType = Type.GetType("System.Collections.Generic.List`1[System.String]");
                        methodInfo = operandType.GetMethod(ruleConditionDetails.ConditionOperatorToApply);
                        var rightOperand =
                            Expression.Constant(Convert.ChangeType(ruleConditionDetails.ParameterValue, operandType));
                        expression = Expression.Call(rightOperand, methodInfo, leftOperand);
                    }
                }
                return expression;
            }
            private static string GetExpressionOperator(string expressionOperator)
            {
                string tempOperator = null;
                switch (expressionOperator)
                {
                    case "==":
                        tempOperator = "Equal";
                        break;
                    case ">":
                        tempOperator = "GreaterThan";
                        break;
                    case ">=":
                        tempOperator = "GreaterThanOrEqual";
                        break;
                    case "<":
                        tempOperator = "LessThan";
                        break;
                    case "<=":
                        tempOperator = "LessThanOrEqual";
                        break;
                    case "!=":
                        tempOperator = "NotEqual";
                        break;
                    case "IN":
                        tempOperator = "Contains";
                        break;
                    default:
                        tempOperator = expressionOperator;
                        break;
                }
                return tempOperator;
            }
        }
        public class RuleCondition
        {
            public int RuleId { get; set; }
            public List<RuleConditionDetails> RuleConditionDetails { get; set; }
            public List<RuleOutput> RuleConditionOutput { get; set; }
        }
        public class RuleConditionDetails
        {
            public string RuleParameter { get; set; }
            public string ConditionOperator { get; set; }
            public object ParameterValue { get; set; }
            public string ConditionOperatorToApply { get; set; }
        }
        public class RuleOutput
        {
            public string RuleParameter { get; set; }
            public object ParameterValue { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, object> keyValues = new Dictionary<string, object>();
                keyValues.Add("Parameter1", "XYZ");
                keyValues.Add("Parameter2", 999);
                var rules = GetRuleCondtions();
                IList<PropertyDescriptor> propertyDescriptors = new List<PropertyDescriptor>();
                foreach (var item in keyValues)
                {
                    var valueType = item.Value == null ? typeof(string) : item.Value.GetType();
                    var propertyDescriptor = new PropertyDescriptor(item.Key, valueType);
                    propertyDescriptors.Add(propertyDescriptor);
                }
                DynamicClassBuilder dynamicClassBuilder =
                    new DynamicClassBuilder("RuleEngineInputData", propertyDescriptors);
                var ruleInputDataObject = dynamicClassBuilder.CreateObject();
                RuleEngine.RunRule(rules, ruleInputDataObject);
                Console.ReadKey();
            }
            private static IList<RuleCondition> GetRuleCondtions()
            {
                IList<RuleCondition> conditons = new List<RuleCondition>();
                conditons.Add(new RuleCondition()
                {
                    RuleConditionDetails = new List<RuleConditionDetails>()
                    {
                        new RuleConditionDetails()
                        {
                            RuleParameter = "Parameter1",
                            ConditionOperator = "==",
                            ParameterValue = "XYZ"
                        },
                        new RuleConditionDetails()
                        {
                            RuleParameter = "Parameter2",
                            ConditionOperator = "==",
                            ParameterValue = "999"
                        },
                    },
                });
                return conditons;
            }
        }
    // Code to create type at runtime
        public class DynamicClassBuilder
        {
            AssemblyName asemblyName = null;
            IEnumerable<PropertyDescriptor> propertyDescriptors = null;
            public DynamicClassBuilder(string ClassName, IEnumerable<PropertyDescriptor> propertyDescriptors)
            {
                this.asemblyName = new AssemblyName(ClassName);
                this.propertyDescriptors = propertyDescriptors;
            }
            public Type CreateType()
            {
                // Create the type builder for creating the class
                TypeBuilder typeBuilder = this.GetDynamicTypeBuilder();
                // Create the constructor inside the class
                CreateConstructor(typeBuilder);
                // Create the properties inside the class
                foreach (var propertyDescriptor in propertyDescriptors)
                {
                    CreateProperty(typeBuilder, propertyDescriptor.PropertyName, propertyDescriptor.PropertyType);
                }
                // Create class
                Type type = typeBuilder.CreateTypeInfo();
                return type;
            }
            public object CreateObject()
            {
                // Create the type builder for creating the class
                TypeBuilder typeBuilder = this.GetDynamicTypeBuilder();
                // Create the constructor inside the class
                CreateConstructor(typeBuilder);
                // Create the properties inside the class
                foreach (var propertyDescriptor in propertyDescriptors)
                {
                    CreateProperty(typeBuilder, propertyDescriptor.PropertyName, propertyDescriptor.PropertyType);
                }
                // Create class
                Type type = typeBuilder.CreateTypeInfo();
                return Activator.CreateInstance(type);
            }
            private TypeBuilder GetDynamicTypeBuilder()
            {
                AssemblyBuilder assemblyBuilder =
                    AssemblyBuilder.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
                TypeBuilder typeBuilder = moduleBuilder.DefineType(this.asemblyName.FullName
                    , TypeAttributes.Public |
                      TypeAttributes.Class |
                      TypeAttributes.AutoClass |
                      TypeAttributes.AnsiClass |
                      TypeAttributes.BeforeFieldInit |
                      TypeAttributes.AutoLayout
                    , null);
                //typeBuilder.SetParent(typeof(RuleEngineInputDataBase));
                return typeBuilder;
            }
            private void CreateConstructor(TypeBuilder typeBuilder)
            {
                typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName |
                                                     MethodAttributes.RTSpecialName);
            }
            private void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
            {
                FieldBuilder fieldBuilder =
                    typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
                PropertyBuilder propertyBuilder =
                    typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
                MethodBuilder getPropMthdBldr = typeBuilder.DefineMethod("get_" + propertyName,
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType,
                    Type.EmptyTypes);
                ILGenerator getILGenerator = getPropMthdBldr.GetILGenerator();
                getILGenerator.Emit(OpCodes.Ldarg_0);
                getILGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                getILGenerator.Emit(OpCodes.Ret);
                MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("set_" + propertyName,
                    MethodAttributes.Public |
                    MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig,
                    null, new[] {propertyType});
                ILGenerator setILGenerator = setMethodBuilder.GetILGenerator();
                Label modifyProperty = setILGenerator.DefineLabel();
                Label exitSet = setILGenerator.DefineLabel();
                setILGenerator.MarkLabel(modifyProperty);
                setILGenerator.Emit(OpCodes.Ldarg_0);
                setILGenerator.Emit(OpCodes.Ldarg_1);
                setILGenerator.Emit(OpCodes.Stfld, fieldBuilder);
                setILGenerator.Emit(OpCodes.Nop);
                setILGenerator.MarkLabel(exitSet);
                setILGenerator.Emit(OpCodes.Ret);
                propertyBuilder.SetGetMethod(getPropMthdBldr);
                propertyBuilder.SetSetMethod(setMethodBuilder);
            }
            public object SetPropertyValues(object accessor, IDictionary<string, object> ruleInputData)
            {
                Type accessorType = accessor.GetType();
                foreach (PropertyInfo propertyInfo in accessorType.GetProperties())
                {
                    object propertyValue = null;
                    if (ruleInputData.TryGetValue(propertyInfo.Name, out propertyValue))
                    {
                        if (propertyInfo.CanRead)
                        {
                            propertyValue = Convert.ChangeType(propertyValue, propertyInfo.PropertyType);
                            propertyInfo.SetValue(accessor, propertyValue);
                        }
                    }
                }
                return accessor;
            }
        }
    }
