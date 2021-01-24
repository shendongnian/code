    public sealed partial class ProjectViewer : UserControl
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
                current.TBName.Text = (e.NewValue as Project).ProjName;
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
 
