    public static void SetAndRaise<TViewModel, TProperty>(
        TViewModel vm, Expression<Func<TViewModel, TProperty>> exp, TProperty value)
        where TViewModel : ViewModelBase
    {
        var propertyInfo = (PropertyInfo)((MemberExpression)exp.Body).Member;
        propertyInfo.SetValue(vm, value, null);
        vm.PropertyChanged(propertyInfo.Name);
    }
