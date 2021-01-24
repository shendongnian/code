    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Naslov_rnd;
        private void button1_Click(object sender, EventArgs e)
        {
            Naslov_rnd++;
            TextBox tb = new TextBox();
            VizitKartica.SuspendLayout();
            tb.Location = new Point(0, 0);
            tb.Multiline = true;
            tb.Size = new Size(200, 20);
            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = Color.DodgerBlue;
            tb.ForeColor = Color.White;
            tb.Name = "Naslov_" + Naslov_rnd.ToString();
            tb.Text = "Dodajte Vaš naslov";
            tb.Font = new Font("Microsoft Sans Serif", 12);
            VizitKartica.Controls.Add(tb);
            VizitKartica.ResumeLayout(true); 
            tb.MouseMove += new MouseEventHandler(tb_MouseMove);
            tb.MouseDown += new MouseEventHandler(tb_MouseDown);
        }
        protected void tb_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox tb2 = (TextBox) sender;
            if (e.Button == MouseButtons.Left)
            {
                tb2.Left = e.X + tb2.Left;
                tb2.Top = e.Y + tb2.Top;
            }
        }
        protected void tb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point MouseDownLocation = e.Location;
            }
        }
    }
