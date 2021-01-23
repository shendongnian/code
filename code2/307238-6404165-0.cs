    class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged( ProeprtyChangedEventArgs e )
        {
            PropertyChanged( this, e );
        }
    
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression )
        {
            // you'll want to add some error checking here
            var name = ((MemberExpression)propertyExpression).Member.Name;
            OnPropertyChanged( new PropertyChangedEventArgs( name ) );
        }
    }
