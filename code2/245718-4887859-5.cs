    class ViewModel : ObservableItem
    {
    
        public ViewModel() : base()
        {
            // Call something to populate DrawingObjects property
            PopulateDrawingObjects();
        }
    
        ObservableCollection<DrawingObject> mDrawingObjects = 
            new ObservableCollection<DrawingObject>();
        public ObservableCollection<DrawingObject> DrawingObjects
        {
            get { return mDrawingObjects; }
            private set { mDrawingObjects = value; }
        }
    }
