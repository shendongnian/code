	private void drawCurvedLine()
	{
		//initialise the plot area:
		Bitmap image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		pictureBox1.BackgroundImage = image;
		using(Graphics g = Graphics.FromImage(image))
		{
			PointF[] points = new PointF[4];
			//first straight:
			points[0] = new PointF(287.284149F, 21.236269F);
			points[1] = new PointF(183.638443F, 406.936249F);
			//second straight:
			points[2] = new PointF(130.842773F, 515.574036F);
			points[3] = new PointF(-1950.91321F, 3491.868F);
			//graphics path for the line:
			using(GraphicsPath gPath = new GraphicsPath())
			{
				gPath.AddLine(points[0], points[1]);
				gPath.AddArc(new RectangleF(-445.464447F, 3.84924316F, 640.067444F, 640.067444F), -(90 - 105.0412369999982F), 10.8775282F);
				gPath.AddArc(new RectangleF(-445.464417F, 3.84915161F, 640.067444F, 640.067444F), -(90 - 115.91811484539707F), 10.8775091F);
				gPath.AddLine(points[2], points[3]);
				//widen the line to the width equal to what the fish will not be able to see:
				using(GraphicsPath innerPath = (GraphicsPath)gPath.Clone())
				{
					using(Pen pen = new Pen(Color.White, 10))
					{
						innerPath.Widen(pen);
					}
					//now exclude that widened line from the main graphics:
					using(Region reg = new Region(innerPath))
					{
						g.ExcludeClip(reg);
						//draw the swathe line:
						//the width of the pen represents the width of a sonar swathe:
						using(Pen widePen = new Pen(new SolidBrush(Color.FromArgb(80, Color.Blue)), 50))
						{
							g.DrawPath(widePen, gPath);
						}
						//reset the clipping for the next line:
						g.ResetClip();
					}
				}
			}
		}
	}
