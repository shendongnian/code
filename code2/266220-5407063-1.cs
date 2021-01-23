    public partial class FormB : Form
    {
        //Event that fires when data is available
        public event EventHandler OnDataAvailable;
        //Properties that expose FormB's data
        public string Text1 { get; private set; }
        public string Text2 { get; private set; }
        public FormB()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Set the exposed properties, then fire off the event.
            this.Text1 = this.textBox1.Text;
            this.Text2 = this.textBox2.Text;
            if (OnDataAvailable != null)
                OnDataAvailable(this, EventArgs.Empty);
        }
    }
