    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int cx = 0;
        private void button1_Click(object sender, EventArgs e)
        {
                TextBox tbxdg = new TextBox();
                tbxdg.Name = "tbx_DG" + cx.ToString();
                tbxdg.Location = new Point(0, 0 + (40 * cx));
                tbxdg.Size = new Size(200, 24);
                tbxdg.Font = new Font("Tahoma", 10);
                panel1.Controls.Add(tbxdg);
                cx++;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            foreach (TextBox tb in panel1.Controls)
            {
                label1.Text += $"{tb.Name} - {tb.Text}\n";
            }
        }
    }
[Demo](https://imgur.com/a/T7PMuVK)
