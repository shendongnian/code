    public void Process(WorkflowPipelineArgs args)
    {
    	//all variables get initialized
    	string contentPath = args.DataItem.Paths.ContentPath;
    	var contentItem = args.DataItem;
    	var contentWorkflow = contentItem.Database.WorkflowProvider.GetWorkflow(contentItem);
    	var contentHistory = contentWorkflow.GetHistory(contentItem);
    	var status = "Approved";
    	var subject = "Item approved in workflow: ";
    	var message = "The above item was approved in workflow.";
    	var comments = args.Comments;
    
    	//Get the workflow history so that we can email the last person in that chain.
    	if (contentHistory.Length > 0)
    	{
    		//submitting user (string)
    		string lastUser = contentHistory[contentHistory.Length - 1].User;
    		var submittingUser = Sitecore.Security.Accounts.User.FromName(lastUser, false);
    
    		//send email however you like (we use postmark, for example)
    		//submittingUser.Profile.Email
    	}
    }
