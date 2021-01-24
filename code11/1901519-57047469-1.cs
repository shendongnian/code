    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var openDbDialog = new OpenDatabaseDialog();
            // Show the form as a dialog and capture the result
            if (openDbDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("You clicked 'Ok' to close the dialog");
            }
            else
            {
                MessageBox.Show("You closed the dialog some other way");
            }
        }
    }
