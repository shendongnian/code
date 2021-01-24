    public static IReadOnlyList<string> EnumerateFile(
			string path,
			bool recursive = false,
			bool ignoreError = true)
		{
			var currentIdentity = WindowsIdentity.GetCurrent();
			List<string> result;
			try
			{
				result = Directory.EnumerateFiles(path).ToList();
				if (recursive)
				{
					foreach(var dir in Directory.EnumerateDirectories(path))
					{
						var r = EnumerateFile(dir, true);
						result.AddRange(r);
					}
				}
				return result;
			}
			catch(UnauthorizedAccessException)
			{
				try
				{
					var accessControl = Directory.GetAccessControl(path);
					accessControl.ModifyAccessRule(
						AccessControlModification.Add,
						new FileSystemAccessRule(
							currentIdentity.User,
							FileSystemRights.ListDirectory,
							AccessControlType.Allow),
						out var success);
					if (!success)
						throw new UnauthorizedAccessException();
					Directory.SetAccessControl(path, accessControl);
					result = Directory.EnumerateFiles(path).ToList();
					if (recursive)
					{
						foreach (var dir in Directory.EnumerateDirectories(path))
						{
							var r = EnumerateFile(dir, true);
							result.AddRange(r);
						}
					}
					accessControl.ModifyAccessRule(
						AccessControlModification.Remove,
						new FileSystemAccessRule(
							currentIdentity.User,
							FileSystemRights.ListDirectory,
							AccessControlType.Allow),
						out _);
					Directory.SetAccessControl(path, accessControl);
					return result;
				}
				catch (UnauthorizedAccessException e)
				{
					return ignoreError ? new List<string>() : throw e;
				}
			}
		}
