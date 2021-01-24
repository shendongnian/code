    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                CheckKeys(e);
            }
            private void CheckKeys(KeyEventArgs e)
            {
                uc1.HandleKeys(e); //Instance method on your user control.
            }
        }
