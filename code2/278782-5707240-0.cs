    public class Notify : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(Expression<Func<object>> exp)
        {
            string propertyName = ((exp.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
