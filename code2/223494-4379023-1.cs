    try
    {
        foreach (Guid currentMember in inactiveMembers)
        {
            RemoveMemberListRequest req = new RemoveMemberListRequest();
            req.ListId = context.PrimaryEntityId;
            req.EntityId = currentMember ;
            RemoveMemberListResponse rmlResp = (RemoveMemberListResponse)crmService.Execute(req);
        }
    }
    catch (SoapException ex)
    {
    	string sExceptionDetail = ex.Detail.InnerText;
    	
    	// write sExceptionDetail somewhere you can look at it
    }
    catch (Exception ex)
    {
        // do your normal error handling here
    }
