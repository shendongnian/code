    public static T GetResource<T>( object key ) where T : class
    {
      return Application.Current.Resources[ key ] as T;
    }
    public static T GetResourceValueType<T>( object key ) where T : struct
    {
      object value = Application.Current.Resources[ key ];
      return (value != null)
        ? (T)value
        : new T();
    }
    public static void SetResource( object key, object resource )
    {
      if ( Application.Current.Resources.Contains( key ) )
        Application.Current.Resources.Remove( key );
      Application.Current.Resources.Add( key, resource );
    }
