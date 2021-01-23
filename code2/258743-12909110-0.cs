    public bool HasAlteredState { get; protected set; }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
    protected virtual void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
    {
        if (selectorExpression == null)
            throw new ArgumentNullException("selectorExpression");
        MemberExpression body = selectorExpression.Body as MemberExpression;
        if (body == null)
            throw new ArgumentException("The body must be a member expression");
        OnPropertyChanged(body.Member.Name);
    }
    protected bool SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        this.HasAlteredState = true;
        OnPropertyChanged(selectorExpression);
        return true;
    }
