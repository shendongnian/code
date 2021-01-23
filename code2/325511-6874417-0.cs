		private static void PinUnpinTaskBar(string filePath, bool pin) {
			if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
			// create the shell application object
			Shell shellApplication = new ShellClass();
			string path = Path.GetDirectoryName(filePath);
			string fileName = Path.GetFileName(filePath);
			Folder directory = shellApplication.NameSpace(path);
			FolderItem link = directory.ParseName(fileName);
			FolderItemVerbs verbs = link.Verbs();
			for (int i = 0; i < verbs.Count; i++) {
				FolderItemVerb verb = verbs.Item(i);
				string verbName = verb.Name.Replace(@"&", string.Empty).ToLower();
				if ((pin && verbName.Equals("pin to taskbar")) || (!pin && verbName.Equals("unpin from taskbar"))) {
					verb.DoIt();
				}
			}
			shellApplication = null;
		}
