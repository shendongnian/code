    ExcelPackage excel = new ExcelPackage();
	var worksheet = excel.Workbook.Worksheets.Add("TreeView Export");
	int rowCounter = 0;
	RecurseNodes(treeView1.Nodes, 1);
	void RecurseNodes(TreeNodeCollection currentNode, int col)
	{
		foreach (TreeNode node in currentNode)
		{
			rowCounter = rowCounter + 1;
			worksheet.Cells[rowCounter, col].Value = node.Text;
			if (node.FirstNode != null)
				RecurseNodes(node.Nodes, col + 1);
		}
	}
	excel.SaveAs(new FileInfo(@"C:\ProgramData\export.xlsx"));
