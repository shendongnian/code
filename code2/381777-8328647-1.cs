    static bool SupportsINotifyPropertyChanged(this Type type)
    {
        return null != type.GetInterface(typeof(INotifyPropertyChanged).FullName);
        // or
        // return type.GetInterfaces().Any(x => x == typeof(INotifyPropertyChanged));
    }
