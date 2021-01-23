    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    static void Main(string[] args)
    {
    	TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("COLLECTION_URL")); //Example: https://xxxx.visualstudio.com
    	var versionControl = tfs.GetService<VersionControlServer>();
    
    	ItemSpec spec = new ItemSpec("$/", RecursionType.Full);
    
    	var folderItemSet = versionControl.GetItems(spec, VersionSpec.Latest, DeletedState.Deleted, ItemType.Folder, true);
    	DestoryItemSet(versionControl, folderItemSet);
    
    	//Delete remaining files
    	var fileItemSet = versionControl.GetItems(spec, VersionSpec.Latest, DeletedState.Deleted, ItemType.File, true);
    	DestoryItemSet(versionControl, fileItemSet);
    }
    
    private static void DestoryItemSet(VersionControlServer versionControl, ItemSet itemSet)
    {
    	foreach (var deletedItem in itemSet.Items)
    	{
    		try
    		{
    			versionControl.Destroy(new ItemSpec(deletedItem.ServerItem, RecursionType.Full, deletedItem.DeletionId), VersionSpec.Latest, null, Microsoft.TeamFoundation.VersionControl.Common.DestroyFlags.None);
    			Console.WriteLine("{0} destroyed successfully.", deletedItem.ServerItem);
    		}
    		catch (ItemNotFoundException) //For get rid of exception for deleting the nested objects
    		{
    
    		}
    		catch (Exception)
    		{
    			throw;
    		}
    	}
    }
