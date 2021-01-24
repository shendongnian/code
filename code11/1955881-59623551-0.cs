    P4Command cmd3 = new P4Command(con, "where", true, "somepath\file.txt");
    P4CommandResult result3 = cmd3.Run();
    if (result3.TaggedOutput!=null)
    	{
    		List<string> depotFiles = new List<string>();
    		foreach(TaggedObject taggedObject in results3.TaggedOutput)
    		{
    			if (taggedObject.ContainsKey("unmap"))
    			{
    				continue;
    			}
    			else
    			{
    				string path = "";
    				taggedObject.TryGetValue("depotFile", out path);
    				depotFiles.Add(path);
    			}
    		}
    	}
