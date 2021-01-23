    public partial class FormA : Form
    {
        //FormA has a private instance of FormB
        private FormB formB = new FormB();
        public FormA()
        {
            InitializeComponent();
            
            //FormA subscribes to FormB's event
            formB.OnDataAvailable += new EventHandler(formB_OnDataAvailable);
        }
        void formB_OnDataAvailable(object sender, EventArgs e)
        {
            //Event handler for when FormB fires off the event
            this.label1.Text = string.Format("Text1: {0}\r\nText2: {1}", 
                formB.Text1, formB.Text2);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            formB.Show();
        }
    }
