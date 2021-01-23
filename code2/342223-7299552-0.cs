    public partial class showCategory : Form
    {
        string categoryId = null;
        private void showCategory_Load(object sender, EventArgs e)
        {
            this.categoryId = "100";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = this.categoryId;
        }
    }
