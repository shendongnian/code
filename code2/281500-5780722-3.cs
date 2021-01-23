    private int m_value;
    public int Value
    {
        get { return m_value; }
        set
        {
            m_value = value;
            RaisePropertyChanged(this, vm => vm.Value);
        }
    }
    static void RaisePropertyChanged<TViewModel, TProperty>(
        TViewModel vm, Expression<Func<TViewModel, TProperty>> exp)
        where TViewModel : ViewModelBase
    {
        var propertyInfo = (PropertyInfo)((MemberExpression)exp.Body).Member;
        vm.PropertyChanged(propertyInfo.Name);
    }
