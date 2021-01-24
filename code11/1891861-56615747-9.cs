    using System.Drawing;
    using System.Windows.Forms;
    public partial class UIATestApp : Form
    {
        public UIATestApp() => InitializeComponent();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var color = Color.FromName((sender as Control).Text);
            pictureBox1.BackColor = (color.IsKnownColor) ? color: Color.White;
        }
    }
