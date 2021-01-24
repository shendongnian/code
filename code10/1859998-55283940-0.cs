    /// <summary>
		/// checks whether the target file needs an update (if it doesn't exist: it needs one)
		/// </summary>
		public static bool NeedsUpdate(FileInfo localFile, DirectoryInfo localDir, DirectoryInfo backUpDir)
		{
			bool needsUpdate = false;
			if (!File.Exists(Path.Combine(backUpDir.FullName, localFile.Name)))
			{
				needsUpdate = true;
			}
			else
			{
				FileInfo backUpFile = new FileInfo(Path.Combine(backUpDir.FullName, localFile.Name));
				DateTime lastBackUp = backUpFile.LastWriteTimeUtc;
				DateTime lastChange = localFile.LastWriteTimeUtc;
				if (lastChange != lastBackUp)
				{
					needsUpdate = true;
				}
				else
				{/*no change*/}
			}
			return needsUpdate;
		}
