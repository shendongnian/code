    public void UpdateAllowedTicketStatusTypes(string statusID)
    {
    switch(statusID){
	    case "TMN":
		    AllowedStatusTypes = AllStatusTypes.Where(o => o.Value == "ASG" || o.Value == "PRC").ToList();
		    break;
	    default:
		    AllowedStatusTypes = AllStatusTypes;
		    break;
    }    
    }
