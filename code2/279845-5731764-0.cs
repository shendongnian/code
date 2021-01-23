	unsafe private void GaussianFilter()
	{
		// Working images
		using (Bitmap newImage = new Bitmap(width, height))
		{
			// Lock bits for performance reason
			BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, newImage.Width,
				newImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			byte* pointer = (byte*)newImageData.Scan0;
			int offset = newImageData.Stride - newImageData.Width * 4;
			// Compute gaussian filter on temp image
			for (int j = 0; j < InputData.Height - 1; ++j)
			{
				for (int 0 = 1; i < InputData.Width - 1; ++i)
				{
					// You browse 4 bytes per 4 bytes
					// The 4 bytes are: B G R A
					byte blue = pointer[0];
					byte green = pointer[1];
					byte red = pointer[2];
					byte alpha = pointer[3];
					// Your business here by setting pointer[i] = ...
					// If you don't use alpha don't forget to set it to 255 else your whole image will be black !!
					// Go to next pixels
					pointer += 4;
				}
				// Go to next line: do not forget pixel at last and first column
				pointer += offset;
			}
			// Unlock image
			newImage.UnlockBits(newImageData);
			newImage.Save("D:\temp\OCR_gray_gaussian.tif");
		}
	}
