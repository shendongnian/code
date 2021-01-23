    // Summary: Notifies clients that a property value is changing, but includes extended event infomation
    /* The following NotifyPropertyChanged Interface is employed when you wish to enforce the inclusion of old and
     * new values. (Users must provide PropertyChangedExtendedEventArgs, PropertyChangedEventArgs are disallowed.) */
    public interface INotifyPropertyChangedExtended<T>
    {
        event PropertyChangedExtendedEventHandler<T> PropertyChanged;
    }
    public delegate void PropertyChangedExtendedEventHandler<T>(object sender, PropertyChangedExtendedEventArgs<T> e);
