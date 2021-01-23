    public abstract class ObservableObject : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	/// <summary>
    	/// Compares the value and sets iff it has changed.
    	/// </summary>
    	/// <typeparam name="T"></typeparam>
    	/// <param name="field">The field.</param>
    	/// <param name="value">The value.</param>
    	/// <param name="propertyName">Name of the property.</param>
    	/// <returns><c>True</c> if the field was changed</returns>
    	protected virtual bool SetValue<T>(ref T field, T value, string propertyName)
    	{
    		return SetValue(ref field, value, propertyName, true);
    	}
    	
    	/// <summary>
    	/// Compares the value and sets iff it has changed.
    	/// </summary>
    	/// <param name="field">The field.</param>
    	/// <param name="value">The value.</param>
    	/// <param name="propertyName">Name of the property.</param>
    	/// <param name="checkForEquality">if set to <c>true</c> [check for equality].</param>
    	/// <returns><c>True</c> if the field was changed</returns>
    	protected virtual bool SetValue<T>(ref T field, T value, string propertyName, bool checkForEquality)
    	{
    		if (checkForEquality && EqualityComparer<T>.Default.Equals(field, value))
    			return false;
    
    		field = value;
    		OnPropertyChanged(propertyName);
    		return true;
    	}
    
    	/// <summary>
    	/// Sets the value.
    	/// </summary>
    	/// <typeparam name="T"></typeparam>
    	/// <param name="setAction">The set action.</param>
    	/// <param name="propertyName">Name of the property.</param>
    	/// <returns></returns>
    	protected virtual bool SetValue(Action setAction, string propertyName)
    	{
    		return SetValue(setAction, null, propertyName);
    	}
    
    	/// <summary>
    	/// Sets the value.
    	/// </summary>
    	/// <typeparam name="T"></typeparam>
    	/// <param name="setAction">The set action.</param>
    	/// <param name="equalityFunc">The equality func.</param>
    	/// <param name="propertyName">Name of the property.</param>
    	/// <returns></returns>
    	protected virtual bool SetValue(Action setAction, Func<bool> equalityFunc, string propertyName)
    	{
    		if (equalityFunc != null && !equalityFunc.Invoke())
    			return false;
    
    		setAction.Invoke();
    		OnPropertyChanged(propertyName);
    		return true;
    	}
    
    	protected void OnPropertyChanged(string propertyName)
    	{
    		OnPropertyChanged(this, propertyName);
    	}
    
    	protected void OnPropertyChanged(object source, string propertyName)
    	{
    		// copying the event handlers before that this is "thread safe"
    		// http://blogs.msdn.com/b/ericlippert/archive/2009/04/29/events-and-races.aspx
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null)
    			handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
