	var files = Directory.GetFiles("\\\\server\\screens\\", "*.jpg");
	var images = new Image[files.Length];
	for(int i = 0; i < files.Length; ++i)
	{
		using(var fs = new FileStream(files[i], FileMode.Open, FileAccess.Read))
		{
			images[i] = System.Drawing.Image.FromStream(fs);
		}
	}
