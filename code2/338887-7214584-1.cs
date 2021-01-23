    public class CanvasViewModel : ViewAware
    {    
        private ObservableCollection<IShape> _shapes;
        public ObservableCollection<IShape> Shapes
        {
            get
            {
               return _shapes;
            }
            set
            {
               _shapes = value;
               NotifyOfPropertyChange(() => Shapes);
               RedrawView();
            }
        }
        
        private void RedrawView()
        {
            ICanvasView abstractView = (ICanvasView)GetView();
            abstractView.DrawShapes();
        }
    }
