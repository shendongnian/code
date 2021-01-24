    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btAddPanel_Click(object sender, EventArgs e)
        {
            CustomPanel customPanel = new CustomPanel();
            this.Controls.Add(customPanel);
        }
    }
    public partial class CustomPanel : Panel
    {
        public CustomPanel()
        {
            // modify properties
            this.BackColor = Color.Red;
            this.Location = new Point(100, 50);
            this.Size = new Size(300, 200);
            // add controls into panel
            TextBox textBox = new TextBox
            {
                Location = new Point(10, 20)
            };
            Label label = new Label
            {
                Text = "Test Label"
            };
            this.Controls.Add(textBox);
            this.Controls.Add(label);
        }
    }
