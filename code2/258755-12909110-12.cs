     public bool HasAlteredState { get; protected set; }
        
     public event PropertyChangedEventHandler PropertyChanged;
    
     private void propertyObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                this.OnPropertyChanged(e.PropertyName);
            }
    
     protected virtual void RegisterSubPropertyForChangeTracking(INotifyPropertyChanged propertyObject)
            {
                propertyObject.PropertyChanged += new PropertyChangedEventHandler(propertyObject_PropertyChanged);
            }
    
     protected virtual void DeregisterSubPropertyForChangeTracking(INotifyPropertyChanged propertyObject)
            {
                propertyObject.PropertyChanged -= propertyObject_PropertyChanged;
            }
    
      protected virtual void OnPropertyChanged(string propertyName)
        {
            this.HasAlteredState = true;
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
            if (field is INotifyPropertyChanged)
            {
                if (field != null) { this.DeregisterSubPropertyForChangeTracking((INotifyPropertyChanged)field); }
            }
            if (value is INotifyPropertyChanged)
            {
                if (value != null) { this.RegisterSubPropertyForChangeTracking((INotifyPropertyChanged)value); }
            }
            field = value;
            OnPropertyChanged(selectorExpression);
            return true;
        }
