    public interface IThemeManager : INotifyPropertyChanged
    {
        event EventHandler CurrentThemeChanged;
        ITheme CurrentTheme { get; set; }
        Dictionary<string, ITheme> AvailableThemes { get; }
    }
