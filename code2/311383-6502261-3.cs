        public byte[] ReadFile(String fileName)
		{
			byte[] bytes;
			using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
			{
				using (IsolatedStorageFileStream file = appStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
				{
					bytes = new byte[file.Length];
					var count = 1024;
                    var read = file.Read(bytes, 0, count);
                    var blocks = 1;
					while(read > 0)
					{
						read = file.Read(bytes, blocks * count, count); 
                        blocks += 1;
					}
				}
			}
			return bytes;
		}
