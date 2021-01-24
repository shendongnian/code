    public partial class Form1 : Form
    {
        private bool Correctway;
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }
        private void Button1_Click(Object sender, EventArgs e)
        {
            PrintPageEventArgs eOutput;
            Graphics g;
            string OutputText;
            Font PrintFont;
            Bitmap Output;
            //Correctway = true;
            OutputText = "CERTIFICATION";
            PrintFont = new Font("Arial", 16, FontStyle.Regular);
            Output = new Bitmap(850, 1100);
            if (Correctway)
                g = Graphics.FromImage(Output);
            else
                g = pictureBox1.CreateGraphics();
            eOutput = new PrintPageEventArgs(g, new Rectangle(new Point(25, 25), new Size(new Point(825, 1075))), new Rectangle(new Point(0, 0), new Size(new Point(850, 1100))), new PageSettings());
            eOutput.Graphics.DrawString(OutputText, PrintFont, Brushes.Black, 0, 0);
            eOutput.Graphics.DrawRectangle(Pens.Gray, 20, 30, Output.Width - 100, Output.Height - 130);
            if (Correctway)
                pictureBox1.Image = Output;
        }
    }
