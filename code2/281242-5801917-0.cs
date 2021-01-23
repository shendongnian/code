    public partial class Main : Form
    {
        public delegate void PassData(ListViewItem itemss);
        public static event PassData PassDataEvent;
        private void ViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PassDataEvent != null)
            {
                PassDataEvent(ViewList.FocusedItem);
            }
        }
    }
    public partial class Properties1 : Form
    {
        public Properties1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Main_Load);
        }
        void Properties1_Load(object sender, EventArgs e)
        {
            Main.PassDataEvent += new Main.PassData(Main_PassDataEvent);
        }
        void Main_PassDataEvent(ListViewItem itemss)
        {
            //do your logic.
        }
    }
