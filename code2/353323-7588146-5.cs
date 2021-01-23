    public class NodeViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _nodeColor;
        public SolidColorBrush NodeColor
        {
            get { return _nodeColor; }
            set
            {
                _nodeColor = value;
                NotifyChange("NodeColor");
            }
        }
        //...
