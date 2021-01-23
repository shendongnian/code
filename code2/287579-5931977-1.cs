    public static IEnumerable<Vector2> IntersectPixels(
						Matrix transformA, int widthA, int heightA, Color[] dataA,
						Matrix transformB, int widthB, int heightB, Color[] dataB)
	{
		// Calculate a matrix which transforms from A's local space into
		// world space and then into B's local space
		Matrix transformAToB = transformA * Matrix.Invert(transformB);
		// When a point moves in A's local space, it moves in B's local space with a
		// fixed direction and distance proportional to the movement in A.
		// This algorithm steps through A one pixel at a time along A's X and Y axes
		// Calculate the analogous steps in B:
		Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
		Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);
		// Calculate the top left corner of A in B's local space
		// This variable will be reused to keep track of the start of each row
		Vector2 yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);
		// For each row of pixels in A
		for(int yA = 0; yA < heightA; yA++)
		{
			// Start at the beginning of the row
			Vector2 posInB = yPosInB;
			// For each pixel in this row
			for(int xA = 0; xA < widthA; xA++)
			{
				// Round to the nearest pixel
				int xB = (int)Math.Round(posInB.X);
				int yB = (int)Math.Round(posInB.Y);
				// If the pixel lies within the bounds of B
				if(0 <= xB && xB < widthB &&
					0 <= yB && yB < heightB)
				{
					// Get the colors of the overlapping pixels
					Color colorA = dataA[xA + yA * widthA];
					Color colorB = dataB[xB + yB * widthB];
					// If both pixels are not completely transparent,
					if(colorA.A != 0 && colorB.A != 0)
					{
						// then an intersection has been found
						yield return Vector2.Transform(new Vector2(xA, yA),transformA);
					}
				}
				// Move to the next pixel in the row
				posInB += stepX;
			}
			// Move to the next row
			yPosInB += stepY;
		}
		// No intersection found
	}
