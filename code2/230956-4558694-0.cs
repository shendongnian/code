	var versionList = new List<string>();
	using(var ndpKey=Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP")) {
		Action<RegistryKey, Action<RegistryKey,string>> processKids = (node, action) => {
			foreach(var childname in node.GetSubKeyNames())
				using(var child = node.OpenSubKey(childname))
					action(child,childname);
		};
		
		Action<RegistryKey, Func<RegistryKey, bool>> visitDescendants = null;
		visitDescendants = (regkey, isDone) => {
			if(!isDone(regkey))
				processKids(regkey, (subkey, subkeyname)=>visitDescendants(subkey,isDone));
		};
			
		processKids(ndpKey, (versionKey, versionKeyName) => {
			if(Regex.IsMatch(versionKeyName,@"^v\d")) {
				visitDescendants(versionKey, key => {
					bool isInstallationNode = Equals(key.GetValue("Install"), 1) && key.GetValue("Version") != null;
					if(isInstallationNode)
						versionList.Add(
							key.Name.Substring(ndpKey.Name.Length+1) 
							+ (key.GetValue("SP")!=null ? ", service pack "+ key.GetValue("SP"):"")
							+ " ("+key.GetValue("Version")  +") "
						);
					return isInstallationNode;
				});
			}
		});
	}
