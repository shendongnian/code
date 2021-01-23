    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            t.Interval = 100;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        Timer t = new Timer();
        int counter = 0;
        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                t.Enabled = false; //Disable timer so we don't start t_Tick when t_Tick is still runnnig
                if (counter == 0)
                {
                    label1.Text = "string1";
                    t.Interval = 3000;
                }
                if (counter == 1)
                {
                    label1.Text = "string2";
                    t.Interval = 5000;
                }
                if (counter == 2)
                {
                    label1.Text = "string3";
                    t.Stop(); //Stop timer
                }
                else
                {
                    t.Enabled = true; //Resume timer
                }
                counter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Never throw exception from timer..." + ex.Message);
            }
            
        }
