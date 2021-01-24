    public partial class Form1 : MyBaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    public class MyBaseForm : Form
    {
        public MyBaseForm()
        {
            TypeDescriptor.AddAttributes(typeof(ImageList.ImageCollection),
                new Attribute[] { 
                    new EditorAttribute(typeof(MyImageListEditor), typeof(UITypeEditor)) });
        }
    }
