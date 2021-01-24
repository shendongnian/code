    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.AddMessageFilter(new MyFilter());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Show();
        }
    }
    public class MyFilter : IMessageFilter
    {
        private const int WM_KEYDOWN = 0x100;
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    switch (m.WParam.ToInt32())
                    {
                        case (int)Keys.Escape:                           
                            Form.ActiveForm.Close();
                            break;
                    }
                    break;
            }
            return false; // returning false allows messages to be processed normally
        }
    }
