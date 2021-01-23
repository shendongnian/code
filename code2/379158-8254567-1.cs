    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            var t = new Timer();
            t.Tick += new EventHandler(GrabData);
            t.Interval = 5000;
            t.Start();
        }
    
        void GrabData(object sender, EventArgs e)
        {
            var data = Task.Factory.StartNew(() =>
            {
                // get and return data
            });
    
            // do something with the data.Result
        }
    }
