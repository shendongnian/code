	var nodeRelationships = new StringBuilder();
	var nodeDetails = new StringBuilder();
	
	foreach(var node in results)
	{
		if(!string.IsNullOrEmpty(node.ParentId))
		{
			nodeRelationships.AppendLine($"\t\"{node.ParentId}\" -> \"{node.Id}\"");
		}
		
		nodeDetails.AppendLine($"\t\"{node.Id}\" [label=\"{node.Name}\"]");
	}
	
	using(StreamWriter sw = new StreamWriter(@"c:\temp\test.dot"))
	{
		sw.WriteLine("digraph G {");
		sw.Write(nodeRelationships.ToString());
		sw.Write(nodeDetails.ToString());
		sw.WriteLine("}");
	}
