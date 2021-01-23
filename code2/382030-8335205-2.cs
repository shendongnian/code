    public abstract class BaseViewModel : INotifyPropertyChanged
    {
    	protected void NotifyPropertyChanged<T>(Expression<Func<T>> expression)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(((MemberExpression)expression.Body).Member.Name));
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
