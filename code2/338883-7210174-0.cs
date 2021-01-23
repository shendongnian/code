    public CanvasView()
    {
       InitializeComponent();
       this.Loaded += this.ViewLoaded;
    }
    
    void ViewLoaded(object sender, PropertyChangedEventArgs e)
    {
       ((CanvasViewModel)this.DataContext).PropertyChanged += new PropertyChangedEventHandler(CanvasView_PropertyChanged);    
    }
    
    void CanvasView_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
       if (e.PropertyName == "Shapes")
       {
          DrawShapes(); 
       }
    }
