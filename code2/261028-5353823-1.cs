			var b = new Bitmap(dataSize.Width, dataSize.Height, PixelFormat.Format32bppArgb);
			using (var g = Graphics.FromImage(b))
			{
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.DrawImage(original, start.X, start.Y, original.Width * ratio, original.Height * ratio);
				if (hasRoundedCorners)
					using (var mask = CreateMask(dataSize, radius))
						TransferChannel(mask, b, ChannelARGB.Blue, ChannelARGB.Alpha);
			}
			return b;
