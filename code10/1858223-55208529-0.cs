	static void Main()
	{
		Color[] colors = new Color[10]
		{
			Color.White, Color.Red, Color.Blue, Color.Green, Color.Black,
			Color.Purple, Color.Brown, Color.Yellow, Color.Gray, Color.Lime
		};
		IEnumerator colorEnum = colors.GetEnumerator();
		Button button = new Button();
		button.FlatStyle = FlatStyle.Flat;
		System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
		tmr.Interval = 250;
		tmr.Tick += (s, e) =>
		{
			if (!colorEnum.MoveNext())
			{
				colorEnum.Reset();
				colorEnum.MoveNext();
			}
			button.BackColor = (Color)colorEnum.Current;
		};
		Form form = new Form();
		form.Shown += (s, e) =>
		{
			tmr.Start();
		};
		form.Controls.Add(button);
		Application.Run(form);
	}
