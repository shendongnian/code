	unsafe
	{
		int colorOffset = 0;
		int pixelOffset = 0;
		byte color = 0;
		byte* pBackBuffer = (byte*)_image.BackBuffer;
		for(int y = 0; y < mapData.Height; y++)
		{
			// get a pointer to first pixel in a line y
			byte* pixLine = pBackBuffer;
			for(int x = 0; x < mapData.Width; x++)
			{
				// fix #1: offset = y * width + x, not y * height + x
				var mapOffset = y * mapData.Width + x;
				
				if (mapData.Data[mapOffset])
				{
					//Set the pixel to white
					color += 1;
				}
				//Shift the pixel position by 1
				color = (byte)(color << 1);
				//If 8 pixels have been written, write it to the backbuffer
				if(++colorOffset == 8)
				{
					*pixLine++ = color;
					color = 0;
					colorOffset = 0;
				}
			}
			// fix #2: copy any pixels left
			if(colorOffset != 0)
			{
				*pixLine++ = color;
				colorOffset = 0;
				color = 0;
			}
			// fix #3: next line offset = previous line + stride, they are aligned
			pBackBuffer += _image.BackBufferStride;
		}
		//Update the image
		_image.AddDirtyRect(new Int32Rect(0, 0, mapData.Width, mapData.Height));
	}
