		public static void TrimTextFile(string fileName, long sizeInByte)
		{
			using(FileStream fs = new FileStream(fileName, FileMode.Open))
			{
				fs.Position = sizeInByte;
				int byteRead = 0;
				while ((byteRead = fs.ReadByte()) >= 0)
				{
					if(byteRead == 13)
					{
						fs.SetLength(fs.Position - 1);
						break;
		
					}
				}
			}
		}
