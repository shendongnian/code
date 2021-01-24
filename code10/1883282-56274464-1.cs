    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(MainForm.Instance.OnMousedown);
            this.label1.MouseDown += new MouseEventHandler(MainForm.Instance.OnMousedown);
        }
    }
