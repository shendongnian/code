    public partial class NodePicture : UserControl
    {
        public NodePicture()
        {
            InitializeComponent();
        }
        public IEnumerable<NodeViewModel> ChildViewModels
        {
            get { return (IEnumerable<NodeViewModel>)GetValue(ChildViewModelsProperty); }
            set { SetValue(ChildViewModelsProperty, value); }
        }
        public static readonly DependencyProperty ChildViewModelsProperty =
            DependencyProperty.Register("ChildViewModels", typeof(IEnumerable<NodeViewModel>), typeof(NodePicture),
            new PropertyMetadata(null, (s, e) => ((NodePicture)s).UpdateCanvas()));
        private void UpdateCanvas()
        {
            this.ParentCanvas.Children.Clear();
            var items = this.ChildViewModels;
            if(items == null)
                return;
            var controls = items.Select(item=>
                {
                    var e = new Ellipse{Width = 20, Height = 20};
                    e.Fill = item.NodeColor;
                    //Or using the data binding
                    //BindingOperations.SetBinding(e, Ellipse.FillProperty, new Binding("NodeColor") { Source = item });
                    Canvas.SetLeft(e, item.LeftOffset);
                    Canvas.SetTop(e, item.TopOffset);
                    return e;
                });
            foreach(var c in controls)
                this.ParentCanvas.Children.Add(c);
        }
