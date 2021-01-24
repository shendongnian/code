    public partial class Form1 : Form
    {
        bool showIcons = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var wt = pictureBox1.ClientSize.Width;
            var ht = pictureBox1.ClientSize.Height;
            // draw grid
            for (int i = 0; i < wt; i+=32)
            {
                e.Graphics.DrawLine(Pens.Black, i, 0, i, ht);
            }
            for (int j = 0; j < ht; j+=32)
            {
                e.Graphics.DrawLine(Pens.Black, 0, j, wt, j);
            }
            if (showIcons)
            {
                // draw icons
                e.Graphics.DrawIcon(SystemIcons.Warning, 5*32-1, 2*32-1);
            }
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            showIcons = true;
            pictureBox1.Refresh();
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            showIcons = false;
            pictureBox1.Refresh();
        }
    }
