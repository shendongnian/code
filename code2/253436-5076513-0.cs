    public class Branch
    {
    	public Branch()
    	{
    		Children = new List<Branch>();
    	}
    
    	public bool IsRoot { get; set; }
    	public int? BranchId { get; set; }
    	public int? ParentId { get; set; }
    	public List<Branch> Children { get; set; }
    	
    	public int HasBranchChildren { get; set; }
    		
    	public string Name { get; set; }
    	//other data
    }
    
    public class BranchTreeHelper
    {
    	public Branch MakeTree() 
    	{
    		var virtualRoot = new Branch()
    		{
    			BranchId = null,
    			ParentId = null,
    			IsRoot = true
    		};
    		
    		// get the data from db
    		List<Branch> branchList = GetDataFromDB();
    		
    		var branchDict = branchList.ToDictionary(i => i.BranchId.Value, i => i);
    		
    		foreach(var branch in branchList)
    		{
    			if(branch.Parent.HasValue)
    			{
    				branchDict[branch.Parent.Value].Children.Add(branch);
    			}
    			else
    			{
    				virtualRoot.Children.Add(branch);
    			}
    		}
    		
    		return virtualRoot;
    	}
    }
