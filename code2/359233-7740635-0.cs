    partial class Form1 : Form
    {
        static bool IsFormOpen;
        public Form1()
        {
            InitializeComponent();
            this.Load += SignalFormOpen;
            this.FormClosing += SignalFormClosed;
        }
        
        void SignalFormOpen(object sender, EventArgs e)
        {
            IsFormOpen = true;
        }
        
        void SignalFormClosed(object sender, EventArgs e)
        {
            IsFormOpen = false;
        }
    }
     
