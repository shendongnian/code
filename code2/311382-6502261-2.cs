        public byte[] ReadFile(String fileName)
		{
			byte[] bytes;
			using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
			{
				using (IsolatedStorageFileStream file = appStorage.OpenFile(GetFileName(), FileMode.Open, FileAccess.Read))
				{
					bytes = new byte[file.Length];
					var count = 1024;
					var read = file.Read(bytes, 0, count);
					while(read > 0)
					{
						read = file.Read(bytes, 0, count);
					}
				}
			}
			return bytes;
		}
