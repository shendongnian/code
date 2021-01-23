    static class ObjectExtensions
    {
    	public static TResult Get<TResult>(this object @this, string propertyName)
        {
            return (TResult)@this.GetType().GetProperty(propertyName).GetValue(@this, null);
        }
    }
