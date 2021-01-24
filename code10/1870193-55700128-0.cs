    public void CreateCampaign()
    {
    	// take local copies of values
    	string campaignName = campaignNameText.text;
    	string ownerName = pInfo.userName;
    
    	if (string.IsNullOrEmpty(campaignName))
    	{
    		DebugLog("invalid campaign name.");
    		return;
    	}
    
    	DebugLog(String.Format("Attempting to add campaign '{0}' for '{1}'... ", campaignName, ownerName));
    	
    	// structure data
    	Dictionary<string, object> newCampaignMap = new Dictionary<string, object>();
    	newCampaignMap["CampaignName"] = campaignName;
    	newCampaignMap["Owner"] = pInfo.userName;
    	newCampaignMap["Members"] = 0;
    
    	DebugLog("Adding to database... ");
    	// get reference and upload data
    	DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(pInfo.userName).Child("Campaigns").Push();
    	reference.SetValueAsync(newCampaignMap)
    		.ContinueWith(task =>
    	{
    		if (task.IsFaulted)
    		{
    			DebugLog(task.Exception.ToString());
    			return;
    		}
    		
    		DebugLog("Campaign " + campaignName + " added successfully.");
    	});
    }
