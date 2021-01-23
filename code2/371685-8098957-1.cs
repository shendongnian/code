    [DesignerAttribute(typeof(MyControlDesigner))]
    public partial class MyControl : UserControl
    {
        ...
        // Using the property "Text" Causes Visual Studio to crash!!!
        public string LabelText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        ...
    }
