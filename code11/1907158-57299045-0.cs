    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // iterate all controls on the form
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    // attach your event's method
                    textBox.KeyDown += OnKeyDown_SelectAllText;
                }
            }
        }
        private void OnKeyDown_SelectAllText(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TextBox textBox = (TextBox) sender;
                textBox.SelectAll();
            }
        }
        // be sure to detach all events when done with form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyDown -= OnKeyDown_SelectAllText;
                }
            }
        }
    }
