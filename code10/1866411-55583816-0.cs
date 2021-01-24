    public class VM: INotifyPropertyChanged
    {
        ...
        public static MainViewModel MainView { get; set; } = new MainViewModel ();
        public static VideoViewModel VideoView { get; set; } = new VideoViewModel ();
        public static AudioViewModel AudioView { get; set; } = new AudioViewModel ();
    }
