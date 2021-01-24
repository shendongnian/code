    public class CanvasViewModel
    {   
        Rectangle r = new Rectangle
        {
            Fill = Brushes.Orange,
            Width = 200,
            Height = 100
        };
        Ellipse e = new Ellipse
        {
            Fill = Brushes.DodgerBlue,
            Width = 100,
            Height = 100
        };
        public Canvas canvas { get; set; }
        public void Initialize()
        {
            canvas = new Canvas();
            Switch(1);
        }
        // Here the contents of the canvas are switched
        // I called it from Click events of two Buttons outside of Frame
        // In your case, I imagine it will be something like this:
        // public void LoadImage(string path) {...}
        public void Switch(int imageNr)
        {
            switch (imageNr)
            {
                case 1:
                        canvas.Children.Clear();
                        canvas.Children.Add(r);
                    break;
                case 2:
                    {
                        canvas.Children.Clear();
                        canvas.Children.Add(e);
                    }
                    break;
                default:
                    break;
            }
        }
        #region CONSTRUCTOR
        static CanvasViewModel() { }
        private CanvasViewModel() { }
        private static CanvasViewModel GetAppViewModelHolder()
        {
            CanvasViewModel vh = new CanvasViewModel();
            vh.Initialize();
            return vh;
        }
        #endregion
        #region SINGLETON Instance
        private static readonly object _syncRoot = new object();
        private static volatile CanvasViewModel instance;
        public static CanvasViewModel Instance
        {
            get
            {
                var result = instance;
                if (result == null)
                {
                    lock (_syncRoot)
                    {
                        if (instance == null)
                        {
                            result = instance = GetAppViewModelHolder();
                        }
                    }
                }
                return result;
            }
        }
        #endregion
    }
