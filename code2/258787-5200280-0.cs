		private Bitmap RotateImage(Bitmap b, float Angle) {
			// The original bitmap needs to be drawn onto a new bitmap which will probably be bigger 
			// because the corners of the original will move outside the original rectangle.
			// An easy way (OK slightly 'brute force') is to calculate the new bounding box is to calculate the positions of the 
			// corners after rotation and get the difference between the maximum and minimum x and y coordinates.
			float wOver2 = b.Width / 2.0f;
			float hOver2 = b.Height / 2.0f;
			float radians = -(float)(Angle / 180.0 * Math.PI);
			// Get the coordinates of the corners, taking the origin to be the centre of the bitmap.
			PointF[] corners = new PointF[]{
				new PointF(-wOver2, -hOver2),
				new PointF(+wOver2, -hOver2),
				new PointF(+wOver2, +hOver2),
				new PointF(-wOver2, +hOver2)
			};
			for (int i = 0; i < 4; i++) {
				PointF p = corners[i];
				PointF newP = new PointF((float)(p.X * Math.Cos(radians) - p.Y * Math.Sin(radians)), (float)(p.X * Math.Sin(radians) + p.Y * Math.Cos(radians)));
				corners[i] = newP;
			}
			// Find the min and max x and y coordinates.
			float minX = corners[0].X;
			float maxX = minX;
			float minY = corners[0].Y;
			float maxY = minY;
			for (int i = 1; i < 4; i++) {
				PointF p = corners[i];
				minX = Math.Min(minX, p.X);
				maxX = Math.Max(maxX, p.X);
				minY = Math.Min(minY, p.Y);
				maxY = Math.Max(maxY, p.Y);
			}
			// Get the size of the new bitmap.
			SizeF newSize = new SizeF(maxX - minX, maxY - minY);
			// ...and create it.
			Bitmap returnBitmap = new Bitmap((int)Math.Ceiling(newSize.Width), (int)Math.Ceiling(newSize.Height));
			// Now draw the old bitmap on it.
			using (Graphics g = Graphics.FromImage(returnBitmap)) {
				g.TranslateTransform(newSize.Width / 2.0f, newSize.Height / 2.0f);
				g.RotateTransform(Angle);
				g.TranslateTransform(-b.Width / 2.0f, -b.Height / 2.0f);
				g.DrawImage(b, 0, 0);
			}
			return returnBitmap;
		}
