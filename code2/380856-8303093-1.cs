		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
		{
			base.OnPaint(pe);
			pe.Graphics.FillRectangle(new System.Drawing.SolidBrush(this.BackColor), pe.ClipRectangle);
			System.Drawing.Rectangle DestinationRect = GetDestinationRectangle(pe.ClipRectangle);
			if(DestinationRect != System.Drawing.Rectangle.Empty)
			{
				System.Drawing.Image BlendedImage = (System.Drawing.Image) this.Image.Clone();
				if(HighlightRegion != System.Drawing.Rectangle.Empty && this.Image != null)
				{
					System.Drawing.Rectangle OffsetHighlightRegion = 
						new System.Drawing.Rectangle(
							new System.Drawing.Point(
								Math.Min(Math.Max(HighlightRegion.X + OffsetX, 0), BlendedImage.Width - HighlightRegion.Width -1), 
								Math.Min(Math.Max(HighlightRegion.Y + OffsetY, 0), BlendedImage.Height - HighlightRegion.Height -1)
								)
								, HighlightRegion.Size
								);
					System.Drawing.Bitmap BlendedBitmap = (System.Drawing.Bitmap) BlendedImage;
					System.Drawing.Color OffsetRGB = GetOffsets(BlendedImage.PixelFormat);
					byte BlendR = SelectionColor.R;
					byte BlendG = SelectionColor.G;
					byte BlendB = SelectionColor.B;
					byte BlendBorderR = SelectionBorderColor.R;
					byte BlendBorderG = SelectionBorderColor.G;
					byte BlendBorderB = SelectionBorderColor.B;
					if(OffsetRGB != System.Drawing.Color.White) //White means not supported
					{
						int BitWidth = OffsetRGB.G - OffsetRGB.R;
						System.Drawing.Imaging.BitmapData BlendedData = BlendedBitmap.LockBits(new System.Drawing.Rectangle(0, 0, BlendedBitmap.Width, BlendedBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, BlendedBitmap.PixelFormat);
						int StrideWidth = BlendedData.Stride;
						int BytesPerColor = OffsetRGB.A;
						int ROffset = BytesPerColor - (OffsetRGB.R + 1);
						int GOffset = BytesPerColor - (OffsetRGB.G + 1);
						int BOffset = BytesPerColor - (OffsetRGB.B + 1);
						byte[] BlendedBytes = new byte[Math.Abs(StrideWidth) * BlendedData.Height];
						System.Runtime.InteropServices.Marshal.Copy(BlendedData.Scan0, BlendedBytes, 0, BlendedBytes.Length);
						//Create Highlighted Region
						for(int Row = OffsetHighlightRegion.Top ; Row <= OffsetHighlightRegion.Bottom ; Row++)
						{
						    for(int Column = OffsetHighlightRegion.Left ; Column <= OffsetHighlightRegion.Right ; Column++)
						    {
						        int Offset = Row * StrideWidth + Column * BytesPerColor;
						        if(Row == OffsetHighlightRegion.Top || Row == OffsetHighlightRegion.Bottom || Column == OffsetHighlightRegion.Left || Column == OffsetHighlightRegion.Right)
						        {
						            BlendedBytes[Offset + ROffset] = BlendBorderR;
						            BlendedBytes[Offset + GOffset] = BlendBorderG;
						            BlendedBytes[Offset + BOffset] = BlendBorderB;
						        }
						        else
						        {
						            BlendedBytes[Offset + ROffset] = (byte) ((BlendedBytes[Offset + ROffset] + BlendR) >> 1);
						            BlendedBytes[Offset + GOffset] = (byte) ((BlendedBytes[Offset + GOffset] + BlendG) >> 1);
						            BlendedBytes[Offset + BOffset] = (byte) ((BlendedBytes[Offset + BOffset] + BlendB) >> 1);
						        }
						    }
						}
						System.Runtime.InteropServices.Marshal.Copy(BlendedBytes, 0, BlendedData.Scan0, BlendedBytes.Length);
						BlendedBitmap.UnlockBits(BlendedData);
						//base.Image = (System.Drawing.Image) BlendedBitmap;
					}
				}
				pe.Graphics.DrawImage(BlendedImage, 0, 0, DestinationRect, System.Drawing.GraphicsUnit.Pixel);
			}
		}
