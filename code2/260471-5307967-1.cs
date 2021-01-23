    public void PopulateTreeview()
	{
		TreeNode depotNode = new TreeNode("//depot");
			
		P4Connection p4 = new P4Connection();
		p4.Connect();
		ProcessFolder(p4, "//depot", depotNode);
		treeView.Nodes.Add(depotNode);
	}
	public void ProcessFolder(P4Connection p4, string folderPath, TreeNode node)
	{
		P4RecordSet folders = p4.Run("dirs", folderPath + "/*");
		foreach(P4Record folder in folders)
		{
			string newFolderPath = folder["dir"];
			string[] splitFolderPath = newFolderPath.Split('/');
			string folderName = splitFolderPath[splitFolderPath.Length - 1];
			TreeNode folderNode = new TreeNode(folderName);
			ProcessFolder(p4, newFolderPath, folderNode);
			node.Nodes.Add(folderNode);
		}
		P4RecordSet files = p4.Run("fstat", folderPath + "/*");
		foreach(P4Record file in files)
		{
			string[] splitFilePath = file["depotFile"].Split('/');
			string fileName = splitFilePath[splitFilePath.Length - 1];
			TreeNode fileNode = new TreeNode(fileName);
			node.Nodes.Add(fileNode);
		}
	}
