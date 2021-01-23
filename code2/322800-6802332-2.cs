		/// <summary>
		/// Calculate the scaling required to fit a rectangle into a rotation of that same rectangle
		/// </summary>
		/// <param name="rotation">Rotation in degrees</param>
		/// <param name="pixelWidth">Width in pixels</param>
		/// <param name="pixelHeight">Height in pixels</param>
		/// <returns>A scaling value between 1 and 0</returns>
		/// <remarks>Released to the public domain 2011 - David Johnston (HiTech Magic Ltd)</remarks>
		private double CalculateConstraintScale(double rotation, int pixelWidth, int pixelHeight)
		{
			// Convert angle to radians for the math lib
			double rotationRadians = rotation * PiDiv180;
			// Centre is half the width and height
			double width = pixelWidth / 2.0;
			double height = pixelHeight / 2.0;
			double radius = Math.Sqrt(width * width + height * height);
			// Convert BR corner into polar coordinates
			double angle = Math.Atan(height / width);
			// Now create the matching BL corner in polar coordinates
			double angle2 = Math.Atan(height / -width);
			// Apply the rotation to the points
			angle += rotationRadians;
			angle2 += rotationRadians;
			// Convert back to rectangular coordinate
			double x = Math.Abs(radius * Math.Cos(angle));
			double y = Math.Abs(radius * Math.Sin(angle));
			double x2 = Math.Abs(radius * Math.Cos(angle2));
			double y2 = Math.Abs(radius * Math.Sin(angle2));
			// Find the largest extents in X & Y
			x = Math.Max(x, x2);
			y = Math.Max(y, y2);
			// Find the largest change (pixel, not ratio)
			double deltaX = x - width;
			double deltaY = y - height;
			// Return the ratio that will bring the largest change into the region
			return (deltaX > deltaY) ? width / x : height / y;
		}
