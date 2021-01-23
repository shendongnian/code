    public class Window1 : Window, INotifyPropertyChanged
    {
        private double m_glowSize;
        public double GlowSize
        {
            get { return m_glowSize; }
            set
            {
                m_glowSize = value;
                NotifyPropertyChanged("GlowSize");
            }
        }
        
        public Window1() //this is my class constructor
        {
            DataContext = this;
            InitializeComponent();
        }  
     
        private void Canvas_MouseMove(object sender, MouseEventArgs e) 
        {
            Canvas canvas = sender as Canvas;
            if (canvas != null)
            {
                Point mousePosition = e.GetPosition(canvas);
                GlowSize = 20 * (mousePosition.X / canvas.ActualWidth);
            }
         }    
        private void NotifyPropertyChanged(string s)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
    }
