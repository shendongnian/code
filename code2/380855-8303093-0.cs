		private System.Drawing.Color GetOffsets(System.Drawing.Imaging.PixelFormat PixelFormat)
		{
			//Alpha contains bytes per color,
			// R contains R offset in bytes
			// G contains G offset in bytes
			// B contains B offset in bytes
			switch(PixelFormat)
			{
				case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
					return System.Drawing.Color.FromArgb(3, 0, 1, 2);
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
				case System.Drawing.Imaging.PixelFormat.Format32bppPArgb:
					return System.Drawing.Color.FromArgb(4, 1, 2, 3);
				case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
					return System.Drawing.Color.FromArgb(4, 0, 1, 2);
				case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
					return System.Drawing.Color.White;
				default:
					return System.Drawing.Color.White;
			}
		}
