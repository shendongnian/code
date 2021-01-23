    public partial class ssplashscreen : Form
        {
            public ssplashscreen()
            {
                
                InitializeComponent();
    
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                progressBar1.Increment(1);
                if (progressBar1.Value == 100)
                {
                    timer1.Stop();
                    this.Hide();
                    Form frm = new login();
                    frm.Show();
                   
                }
    
                
            }
    
           
        }
