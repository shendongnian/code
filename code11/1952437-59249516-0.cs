    public sealed class MyGridView : GridView
    {
        public MyGridView()
        {
            this.DefaultStyleKey = typeof(GridView);
        }
    
        public DependencyObject GetChildWithName(string childName)
        {
            return GetTemplateChild(childName);
        }
    }
