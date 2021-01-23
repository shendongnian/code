		string assembly = null;
		string directory = null;
		string lockfile = null;
		string name = null;
		string logname = null;
		var assebmlyArgs = new List<string>();
		foreach (string s in args){
			if (s.Length > 3 && s [0] == '-' && s [2] == ':'){
				string arg = s.Substring (3);
				switch (Char.ToLower (s [1])){
				case 'd': directory = arg; break;
				case 'l': lockfile = arg; break;
				case 'n': name = arg; break;
				case 'm': logname = arg; break;
				default: Usage (); break;
				}
			} else {
				if (assembly != null)
				{
					assebmlyArgs.Add(s);
				}
				else
				{
					assembly = s;
				}
			}
		}
