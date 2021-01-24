    public class MyVisualHost : FrameworkElement
    {
        public VisualCollection children;
        public MyVisualHost()
        {
            children = new VisualCollection(this);
            children.Add(new Button() {Name = "button"});
            children.Add(new TextBox() {Name = "textbox"});
        }
        protected override int VisualChildrenCount
        {
            get { return children.Count; }
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= children.Count)
                throw new ArgumentOutOfRangeException();
            return children[index];
        }
        public int Count => VisualChildrenCount;
        public Visual this[int index]
        {
            get { return GetVisualChild(index); }
        }
    }
