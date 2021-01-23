			using (Bitmap bmp = new Bitmap(100, 100)) 
				{
				using (Graphics g = Graphics.FromImage(bmp)) 
					{
					g.FillRectangle(Brushes.Green, 0, 0, bmp.Width, bmp.Height);
					g.FillRectangle(Brushes.Red, 10, 10, 50, 50);
					g.FillRectangle(Brushes.Blue, 20, 20, 50, 50);
					pictureBox1.Image = bmp;
					pictureBox1.Update(); // force an update before doing anything with it
					Graphics g2 = pictureBox1.CreateGraphics();
					var bmp2 = GraphicsBitmapConverter.GraphicsToBitmap(g2, Rectangle.Truncate(g.VisibleClipBounds)); 
					// bmp2 now has the same contents as bmp1
					pictureBox1.Image = null; // bmp is about to be Disposed so remove the reference to it
					}
				}
