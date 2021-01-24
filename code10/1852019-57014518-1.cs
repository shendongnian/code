cs
		public static void TestDrawTransparent()
		{
			//This code will, successfully, draw something transparent overwriting an opaque area.
			//More precisely, it creates a 100*100 fully-opaque red square with a 50*50 semi-transparent center.
			using(Bitmap bmp = new Bitmap(100, 100, PixelFormat.Format32bppArgb))
			{
				using(Graphics g = Graphics.FromImage(bmp))
				using(Brush opaqueRedBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0)))
				using(Brush semiRedBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
				{
					g.Clear(Color.Transparent);
					Rectangle bigRect = new Rectangle(0, 0, 100, 100);
					Rectangle smallRect = new Rectangle(25, 25, 50, 50);
					g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					g.FillRectangle(opaqueRedBrush, bigRect);
					g.FillRectangle(semiRedBrush, smallRect);
				}
				bmp.Save(@"C:\FilePath\TestDrawTransparent.png", ImageFormat.Png);
			}
		}
In this code, I first draw a fully-opaque red square, then a semi-transparent red square "over" it. The result is a semi-transparent "hole" in the square:
[![Red square with semi-transparent center][2]][2]
And on a black background:
[![The square with semi-transparent hole, on a black background][1]][1]
A zero-opacity brush works just as well, leaving a clear hole through the image (I checked).
With that in mind, you should be able to crop any shapes you want, simply by filling them with a zero-opacity brush.
  [1]: https://i.stack.imgur.com/9WW9m.png
  [2]: https://i.stack.imgur.com/8M1U0.png
