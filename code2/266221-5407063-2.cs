    public partial class FormA : Form
    {
        //FormA has a private instance of FormB
        private FormB formB = null;
        public FormA()
        {
            InitializeComponent();
        }
        void formB_OnDataAvailable(object sender, EventArgs e)
        {
            //Event handler for when FormB fires off the event
            this.label1.Text = string.Format("Text1: {0}\r\nText2: {1}", 
                formB.Text1, formB.Text2);
        }
        private void InitializeFormB()
        {
            this.formB = new FormB();
            //FormA subscribes to FormB's event
            formB.OnDataAvailable += new EventHandler(formB_OnDataAvailable);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.InitializeFormB();
            formB.Show();
        }
    }
