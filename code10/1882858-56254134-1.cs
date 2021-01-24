namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //loop through all the buttons and assign to btnClick
            var c = GetAll(this, typeof(Button));
            foreach (var item in c)
            {
                item.Click += btnClick;
            }
        }
        private void btnClick(object sender, EventArgs e)
        {
            //The sender is a Button so you find the text and append it to your textbox/output
            txtOutput.Text += ((sender as Button).Text);
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
Hope this helps in guiding you in the right direction.
