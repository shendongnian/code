    static bool SupportsINotifyPropertyChanged(this Type type)
    {
        return type.GetInterface(typeof(INotifyPropertyChanged).ToString());
        // or
        // return type.GetInterfaces().Any(x => x == typeof(INotifyPropertyChanged));
    }
