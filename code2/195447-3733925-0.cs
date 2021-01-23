    private readonly object _sync = new object();
    
    public event PropertyChangedEventHandler PropertyChanged
    {
       add { lock (_sync) _propertyChanged += value; }
       remove { lock (_sync) _propertyChanged -= value; }
    } private PropertyChangedEventHandler _propertyChanged;
    
    protected void OnPropertyChanged(Expression<Func<object>> propertyExpression)
    {
       OnPropertyChanged(GetPropertyName(propertyExpression));
    }
    
    protected string GetPropertyName(Expression<Func<object>> propertyExpression)
    {
        MemberExpression body;
    
        if (propertyExpression.Body is UnaryExpression)
            body = (MemberExpression) ((UnaryExpression) propertyExpression.Body).Operand;
        else
            body = (MemberExpression) propertyExpression.Body;
    
        return body.Member.Name;
    }
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
      var handler = _propertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
