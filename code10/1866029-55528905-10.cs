    namespace WindowsFormsApp1
    {
    public partial class Form2 : Form
    {
        static public Label label2 = new Label();
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Location = new Point(20, 20);
            Controls.Add(label2);
            label2.Text = "mama";
        }
    }
    }
