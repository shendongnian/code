    public partial class UIManager
    {
        private Form2 f1;
        private Form2 f2;
        private bool shouldShowForm2 = false;
        public bool ShouldShowForm2 
        { 
           get { return shouldShowForm2; }
           set { shouldShowForm2 = value;  ShouldShowForm2Changed(); }
        }
        public UIManager()
        {
            InitializeComponent();
            // Initialize Forms
            f1 = new Form1();
            f2 = new Form2();
            f1.Resize += new System.EventHandler(f1_Resize);
        }
        void f1_Resize(object sender, System.EventArgs e)
        {
           // whenever I change the size of Form1, make sure 
           // Form2 has the same WindowState
           f2.WindowState = f1.WindowState;
        }
        // This is your condition to either show or hide the form.
        private void ShouldShowForm2Changed(object sender, EventArgs e)
        {
            if (ShouldShowForm2)
            {
                f2.Show();
            }
            else
            {
                f2.Hide();
            }
        }
    }
