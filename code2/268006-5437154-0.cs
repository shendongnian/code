    public class MainViewModel
    {
        public MainViewModel()
        {
            //For demonstration
            this.ViewUIElements = new ObservableCollection<VisualQueryObject>
            {
                new VisualQueryObject{LabelType = "column", ColumnDiscriptor = new DescriptionModel("Table1", "Column2") },
                new VisualQueryObject{LabelType = "controller"},
                new VisualQueryObject{LabelType = "value"},
            };
        }
        public void UpdateCollection(VisualQueryObject helperVisualQueryObject)
        {
            VisualQueryObject visualQueryData = new VisualQueryObject();
            //I would remove copying, but maybe it is intended behavior
            //***Taking a copy of the static DraggedData object to be bound           
            visualQueryData.ColumnDiscriptor = helperVisualQueryObject.ColumnDiscriptor;
            visualQueryData.ComparedValue = helperVisualQueryObject.ComparedValue;
            visualQueryData.JoinWithColumnDescriptor = helperVisualQueryObject.JoinWithColumnDescriptor;
            visualQueryData.LabelType = helperVisualQueryObject.LabelType;
            visualQueryData.OperatorValue = helperVisualQueryObject.OperatorValue;
            this.ViewUIElements.Add(visualQueryData);
            //QueryDesignerModel.QueryDesignHelperCollection.Add(visualQueryData);   //I don't know what this method does
        }
        public ObservableCollection<VisualQueryObject> ViewUIElements { get; private set; }
    }
