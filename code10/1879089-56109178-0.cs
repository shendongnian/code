    public sealed partial class ProjectViewer : UserControl, INotifyPropertyChanged
    {
        public ProjectViewer()
        {
            this.InitializeComponent();
        }
    
    
        public Project ProjectSource
        {
            get { return (Project)GetValue(ProjectSourceProperty); }
            set { SetValue(ProjectSourceProperty, value); }
        }
    
        public static readonly DependencyProperty ProjectSourceProperty =
            DependencyProperty.Register("ProjectSource", typeof(Project), typeof(ProjectViewer), new PropertyMetadata(0, new PropertyChangedCallback(CallBack)));
    
        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as ProjectViewer;
            if (e.NewValue != e.OldValue)
            {
                current.Title = (e.NewValue as Project).ProjName;
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }
    
    public class Project
    {
        public string ProjName { get; set; }
    
        public Project()
        {
        }
    }
