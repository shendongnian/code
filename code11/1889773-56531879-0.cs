	private Image ImgA;
	private Image ImgB;
	private Boolean? BackgroundA = true;
	private void Form1_Load(object sender, EventArgs e)
	{
		ImgA = Image.FromFile(Path.Combine("F:/test", "A.png"));
		ImgB = Image.FromFile(Path.Combine("F:/test", "B.png"));
		this.MouseMove += Form1_MouseMove;
	}
	private void Form1_MouseMove(object sender, MouseEventArgs e)
	{
		SetBackground();
	}
	private void SetBackground()
	{
		Boolean curA = (MousePosition.X <= 960);
		if (!BackgroundA.HasValue || BackgroundA.Value != curA)
		{
			BackgroundA = curA;
			this.BackgroundImage = BackgroundA.Value ? ImgA : ImgB;
		}
	}
