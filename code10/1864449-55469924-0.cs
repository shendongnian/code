    public partial class FormC : Form
    {
        public static event FormClosedEventHandler InstanceClosed;
        public FormC()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) =>
            {
                InstanceClosed?.Invoke(sender, e);
            };
        }
    }
