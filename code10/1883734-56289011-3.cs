    public partial class Form2 : Form
    {
        public static bool BolleanProperty { get; set; }
        static Form2()
        {
            BolleanProperty = true;
        }
        public Form2()
        {
            InitializeComponent();
        }
    }
