        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
                //In the constructor
                this.Size = new Size(100, 100);
            }
            //Or in an event
            private void Form1_Load(object sender, EventArgs e) => this.Size = new Size(100, 100);
        }
