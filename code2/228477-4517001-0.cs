         public partial class Form1 : Form
        {
            private delegate void TickerDelegate();
            TickerDelegate tickerDelegate1;
           
            public Form1()
            {
                InitializeComponent();
            }
       //first solution
       // This button event call other class having Thread
            
           private void button1_Click(object sender, EventArgs e) 
            {
                f = new FormFileUpdate("Auto File Updater", this);
                f.Visible = true;
                this.Visible = false;         
            }
    
            // Second Solution
            private void BtnWatch_Click(object sender, EventArgs e)
            {
                tickerDelegate1 = new TickerDelegate(SetLeftTicker);
                Thread th = new Thread(new ThreadStart(DigitalTimer));
                th.IsBackground = true;
                th.Start();
             }
            private void SetLeftTicker()
            {
                label2.Text=DateTime.Now.ToLongTimeString();
            }
    
           
            public void DigitalTimer()
            {
                while (true)
                {
                    label2.BeginInvoke(tickerDelegate1, new object[] {});
                    Thread.Sleep(1000);
                }
            }
        }
    
    
     
