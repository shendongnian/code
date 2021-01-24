    internal class PersonMetaObject : DynamicMetaObject {
        private TypeInfo _typeInfo = typeof(Person).GetTypeInfo();
    
        public PersonMetaObject(Expression parameter, Person value)
            : base(parameter, BindingRestrictions.Empty, value) { }
    
        public override DynamicMetaObject BindGetMember(GetMemberBinder binder) {
            Expression self = GetSelfExpression();
    
            string propertyName = binder.Name;
    
            return BindGetInternal(self, propertyName);
        }
    
        public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes) {
            Expression self = GetSelfExpression();
    
            string propertyName = indexes.First().Value.ToString();
    
            return BindGetInternal(self, propertyName);
        }
    
        private DynamicMetaObject BindGetInternal(Expression self, string propertyName) {
            switch (propertyName) {
                // Dynamic value computed in runtime
                case "FullName": {
                    // Get FirstName property
                    Expression firstName = Expression.Property(self, nameof(Person.FirstName));
                    // Get LastName property
                    Expression lastName = Expression.Property(self, nameof(Person.LastName));
                    // Create constant containing space character
                    Expression space = Expression.Constant(" ");
    
                        
                    Expression stringArray = Expression.NewArrayInit(typeof(string), firstName, lastName);
    
                    Expression fullName = Expression.Call(null, typeof(string).GetMethod(nameof(String.Join), new[] { typeof(string), typeof(string[]) }), space, stringArray);
    
                    // Create and return dynamic object metadata
                    return new DynamicMetaObject(Expression.Convert(fullName, typeof(object)), BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                }
                // Defined method invoked
                case "Age": {
                    // Get method info using type reflection
                    MethodInfo getAge = _typeInfo.GetMethod(nameof(Person.GetAge));
    
                    // Call reflected method
                    Expression age = Expression.Call(self, getAge);
    
                    // Create and return dynamic object metadata
                    return new DynamicMetaObject(Expression.Convert(age, typeof(object)), BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                }
                // 
                default: {
                    // if none case was hit we need to make sure to return declared property if exists
                    if(_typeInfo.GetMembers().Any(m => m.Name == propertyName)) {
                        return new DynamicMetaObject(Expression.Convert(Expression.Property(self, propertyName), typeof(object)), BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                    }
                    // If we get here something is wrong. To avoid exception we just return default value. But you would like to change it accordingly   
                    // Create default object
                    Expression @default = Expression.Default(typeof(object));
    
                    // Create and return dynamic object metadata
                    return new DynamicMetaObject(@default, BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                }
            }
        }
        private Expression GetSelfExpression() {
            return Expression.Convert(Expression, LimitType);
        }
    }
