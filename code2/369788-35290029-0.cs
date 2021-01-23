    public partial class Form2 : Form
        {
            static int VALIDATION_DELAY = 1500;
            System.Threading.Timer timer = null;
            public Form2()
            {
                InitializeComponent();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                TextBox origin = sender as TextBox;
                if (!origin.ContainsFocus)
                    return;
    
                DisposeTimer();
                timer = new System.Threading.Timer(TimerElapsed, null, VALIDATION_DELAY, VALIDATION_DELAY);
    
            }
            private void TimerElapsed(Object obj)
            {
                CheckSyntaxAndReport();
                DisposeTimer();            
            }
    
            private void DisposeTimer()
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            }
    
            private void CheckSyntaxAndReport()
            {            
                this.Invoke(new Action(() => 
                {
                    string s = textBox1.Text.ToUpper(); //Do everything on the UI thread itself
                    label1.Text = s; 
                }
                    ));            
            }
        }
