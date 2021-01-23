    public Form1()
        {
            InitializeComponent();
            this.FormClosing += ThisFormClosing;
        }
        void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (YouDontWantToClose)
            {
                e.Cancel = true;
                return;
            }
            //Do Some Extra Work Here
        }
