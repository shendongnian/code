public class ViewModelBase : IDataErrorInfo, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public SynchronizationContext Context
    {
        get;
        set;
    }
    public bool HasErrors
    {
        get
        {
            return !string.IsNullOrWhiteSpace(this.Error);
        }
    }
    public string Error
    {
        get 
        {
            var type = this.GetType();
            var modelClassProperties = TypeDescriptor
                .GetProperties(type)
                .Cast<PropertyDescriptor>();
            return
                (from modelProp in modelClassProperties
                    let error = this[modelProp.Name]
                    where !string.IsNullOrWhiteSpace(error)
                    select error)
                    .Aggregate(new StringBuilder(), (acc, next) => acc.Append(" ").Append(next))
                    .ToString();
        }
    }
    public virtual string this[string columnName]
    {
        get
        {
            var type = this.GetType();
            var modelClassProperties = TypeDescriptor
                .GetProperties(type)
                .Cast<PropertyDescriptor>();
            var errorText =
                (from modelProp in modelClassProperties
                    where modelProp.Name == columnName
                    from attribute in modelProp.Attributes.OfType<ValidationAttribute>()
                    from displayNameAttribute in modelProp.Attributes.OfType<DisplayNameAttribute>()
                    where !attribute.IsValid(modelProp.GetValue(this))
                    select attribute.FormatErrorMessage(displayNameAttribute == null ? modelProp.Name : displayNameAttribute.DisplayName))
                    .FirstOrDefault();
            return errorText;
        }
    }
    protected void NotifyPropertyChanged(string propertyName)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            throw new ArgumentNullException("propertyName");
        }
        if (!this.GetType().GetProperties().Any(x => x.Name == propertyName))
        {
            throw new ArgumentException(
                "The property name does not exist in this type.",
                "propertyName");
        }
        var handler = this.PropertyChanged;
        if (handler != null)
        {
            if (this.Context != null)
            {
                this.Context.Post(obj => handler(this, new PropertyChangedEventArgs(propertyName)), null);
            }
            else
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
