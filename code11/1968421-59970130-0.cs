    namespace WindowsFormsApp3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (int.TryParse(apMinBoxTexBox.Text, out var minBoxResult) && int.TryParse(apMinBoxTexBox.Text, out var maxBoxResult))
                {
                    if (maxBoxResult > minBoxResult)
                    {
                        MessageBox.Show("Minimum cannot be greater than the Maximum.");
                    }
                    else
                    {
                        // in range
                    }
                }
                else
                {
                    MessageBox.Show("Please enter numbers");
                }
            }
        }
    }
