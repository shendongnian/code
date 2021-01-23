        public partial class Form1 : Form
    {
        bool fireEvents = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fireEvents) doCheck(sender, e);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fireEvents) doCheck(sender, e);
        }
        private void doCheck(object sender, EventArgs e)
        {
            fireEvents = false; // because we don't have a way to cancel event bubbling
            if (sender == comboBox1)
            {
                comboBox2.SelectedIndex = -1;
            }
            else if (sender == comboBox2)
            {
                comboBox1.SelectedIndex = -1;
            }
            fireEvents = true;
        }
    }
