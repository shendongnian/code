    public override DynamicMetaObject BindGetMember(GetMemberBinder binder) {
        Expression self = Expression.Convert(Expression, LimitType);
        string propertyName = binder.Name;
    
        return BindInternal(self, propertyName);
    }
    
    private DynamicMetaObject BindInternal(Expression self, string propertyName) {
        switch (propertyName) {
            case "AgePlusTwo": {
                Expression age = Expression.Property(self, "Age");
                Expression value = Expression.Constant(2);
                Expression agePlusTwo = Expression.Add(age, value);
    
                return new DynamicMetaObject(Expression.Convert(agePlusTwo, typeof(object)), BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            }
            case "AgePlusTen": {
                Expression agePlusTen = Expression.Property(self, "AgePlusTen");
    
                return new DynamicMetaObject(Expression.Convert(agePlusTen, typeof(object)), BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            }
            default: {
                return new DynamicMetaObject(Expression.Convert(Expression.Property(self, propertyName), typeof(object)), BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            }
        }
    }
