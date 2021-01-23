    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("COLLECTION_URL")); //Example: https://xxxx.visualstudio.com/defaultcollection
    var versionControl = tfs.GetService<VersionControlServer>();
    
    ItemSpec spec = new ItemSpec("$/", RecursionType.Full);
    var found = versionControl.GetItems(spec, VersionSpec.Latest, DeletedState.Deleted, ItemType.Folder, true);
    
    foreach (var deletedItem in found.Items)
    {
    	try
    	{
    		versionControl.Destroy(new ItemSpec(deletedItem.ServerItem, RecursionType.Full, deletedItem.DeletionId), VersionSpec.Latest, null, Microsoft.TeamFoundation.VersionControl.Common.DestroyFlags.None);
    		Console.WriteLine("{0} destroyed successfully.", deletedItem.ServerItem);
    	}
    	catch
    	{
    		
    	}
    }
