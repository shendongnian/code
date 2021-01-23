    public partial class Form2 : Form
    {
        public Form2()
        {
            this.Visible = false;
            this.Opacity = 0;
            InitializeComponent();
            this.TopMost = true; 
            this.Visible = true;
            while (this.Opacity < 1)
            {
               this.Opacity += .05;
               Thread.Sleep(5);
               this.TopMost = true;
            }       
        }
        private void closefade()
        {
            while (this.Opacity > 0)
            {
                this.Opacity -= .05;
                Thread.Sleep(5);
                this.TopMost = true;
            }
            this.Close();
        }
        private void a_Tick(object sender, EventArgs e)
        {
           this.Close();
        }
        delegate void CloseBack();
        public void closethis()
        {
            if (this.InvokeRequired)
            {
                CloseBack b = new CloseBack(closethis);
            }
            else
                closefade();
        }
    }
