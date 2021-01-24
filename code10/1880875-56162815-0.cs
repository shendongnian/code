static void TrimFile(string filePath, byte[] badBytes)
	{
		using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
		{
			byte[] bytes = new byte[badBytes.Length];
			file.Seek(-badBytes.Length, SeekOrigin.End);
			file.Read(bytes, 0, badBytes.Length);
			if (Enumerable.SequenceEqual(bytes, badBytes))
			{
				file.SetLength(Math.Max(0, file.Length - badBytes.Length));
			}                
		}
	}
You can call it like this:
TrimFile(filePath, new byte[] { 0x0A, 0x00 });
Here's a test file I created with `0xCA 0xFE 0xFF 0xFF` at the end (some bunk data)
62 75 6E 6B 20 66 69 6C 65 CA FE FF FF 
bunk fileÊþÿÿ
After running `TrimFile(filePath, new byte[] { 0xCA, 0xFE, 0xFF, 0xFF });`
62 75 6E 6B 20 66 69 6C 65
bunk file
Hope this comes in handy!
