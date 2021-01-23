    public partial class inout_buton : UserControl
        {
            Bitmap bmp;
            public inout_buton()
            {
    
                InitializeComponent();
    
                try
                {
                    bmp = new Bitmap(Network_Remote_Monitoring.Properties.Resources.but_verde.png);
                 }
                catch
                {
                    MessageBox.Show("it's bad");
                }
    
    
                this.BackgroundImage = bmp;
            }
        }
