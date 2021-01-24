    public bool UpdateProfilePic(updateprofilepicmodel model)
    {
    	using (ClientContext context = SPConnection.GetSharePointContext())
    	{
    		List list = context.Web.Lists.GetByTitle("Members");
    		ListItem item = list.GetItemById(model.MemberId);
    		context.Load(item);
            context.ExecuteQuery();
    		item["ProfilePicture"] = model.ProfilepicUrl;
    		item.Update();
    		context.ExecuteQuery();
    		return true;
    	}
    }
