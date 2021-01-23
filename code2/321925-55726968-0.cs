    		public static byte[] Concatenate(IEnumerable<byte[]> sourceData)
		{
			var buffer = new byte[1024 * 4];
			WaveFileWriter waveFileWriter = null;
			using (var output = new MemoryStream())
			{
				try
				{
					foreach (var binaryData in sourceData)
					{
						using (var audioStream = new MemoryStream(binaryData))
						{
							using (WaveFileReader reader = new WaveFileReader(audioStream))
							{
								if (waveFileWriter == null)
									waveFileWriter = new WaveFileWriter(output, reader.WaveFormat);
								else
									AssertWaveFormat(reader, waveFileWriter);
								WaveStreamWrite(reader, waveFileWriter, buffer);
							}
						}
					}
					waveFileWriter.Flush();
					return output.ToArray();
				}
				finally
				{
					waveFileWriter?.Dispose();
				}
			}
		}
		private static void AssertWaveFormat(WaveFileReader reader, WaveFileWriter writer)
		{
			if (!reader.WaveFormat.Equals(writer.WaveFormat))
			{
				throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
			}
		}
		private static void WaveStreamWrite(WaveFileReader reader, WaveFileWriter writer, byte[] buffer)
		{
			int read;
			while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
			{
				writer.Write(buffer, 0, read);
			}
		}
