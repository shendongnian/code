        public CanvasView()
        {
            InitializeComponent();
            Action wireDataContext += new Action ( () => {
                if (DataContext!=null) 
                          ((CanvasViewModel)this.DataContext).PropertyChanged += new PropertyChangedEventHandler(CanvasView_PropertyChanged);
                });
            this.DataContextChanged += (_,__) => wireDataContext();
            wireDataContext();
        }
        void CanvasView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Shapes")
            {
                DrawShapes(); 
            }
        }
