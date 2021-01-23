	public partial class Form1 : Form
	{
		void timer_Tick(object sender, EventArgs e)
		{
			int x = pictureBox1.Location.X;
			int y = pictureBox1.Location.Y;
			pictureBox1.Location = new Point(x+25, y);
			
			if (x > this.Width)
				timer1.Stop();
		}
		public Form1()
		{
			InitializeComponent();
			timer1.Interval = 10;
			timer1.Tick += new EventHandler(timer_Tick);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			pictureBox1.Show();
			timer1.Start();
		 }
	}
