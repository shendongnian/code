    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TransparentPanel panel = new TransparentPanel()
            {
                Location = dateTimePicker1.Location,
                Size = dateTimePicker1.Size,
            };
            this.Controls.Add(panel);
            panel.DoubleClick += Panel_DoubleClick;
            panel.BringToFront();
        }
        private void Panel_DoubleClick(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
        }
    }
