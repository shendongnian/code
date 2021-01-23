	internal static byte[] GetDataToBuffer()
	{
		// set BufferSize to your most common data length
		const int BufferSize = 1024 * 8;
		// list of data blocks
		var chunks = new List<byte[]>();
		int dataRead = 1;
		int position = 0;
		int totalByte = 0;
		while(true)
		{
			var chunk = new byte[BufferSize];
			// get new block of data
			DTS_GetDataToBuffer(position, BufferSize, chunk, ref dataRead);
			position += BufferSize;
			if(dataRead != 0)
			{
				totalBytes += dataRead;
				// append data block
				chunks.Add(chunk);
				if(dataRead < BufferSize)
				{
					break;
				}
			}
			else
			{
				break;
			}
		}
		switch(chunks.Count)
		{
			case 0: // no data blocks read - return empty array
				return new byte[0];
			case 1: // single data block
				if(totalBytes < BufferSize)
				{
					// truncate data block to actual data size
					var data = new byte[totalBytes];
					Array.Copy(chunks[0], data, totalBytes);
					return data;
				}
				else // single data block with size of Exactly BufferSize
				{
					return chunks[0];
				}
			default: // multiple data blocks
				{
					// construct new array and copy all data blocks to it
					var data = new byte[totalBytes];
					position = 0;
					for(int i = 0; i < chunks.Count; ++i)
					{
						// copy data block
						Array.Copy(chunks[0], 0, data, position, Math.Min(totalBytes, BufferSize));
						position += BufferSize;
						// we need to handle last data block correctly,
						// it might be shorted than BufferSize
						totalBytes -= BufferSize;
					}
					return data;
				}
		}
	}
