    public partial class Form1 : Form
    {
        private Button previousButton = null;
        public Form1()
        {
            InitializeComponent();
            button1.Click += Buttons_Click;
            button2.Click += Buttons_Click;
        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            if (previousButton != null)
            {
                // do something with previousButton
            }
            // code to work with the currently clicked button
            // as (Button)sender
            // remember the current button
            previousButton = (Button)sender;
        }
    }
