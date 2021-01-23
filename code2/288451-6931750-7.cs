    public string FindFriendsForTagging(string friendNamePart)
    {
    	friendNamePart = friendNamePart.Remove(0, 1);
    	// Descrption of class FriendManager see below.
    	IQueryable<User> model = new FriendManager().GetFriendsByDisplayName(friendNamePart).Take(10);
    	StringBuilder sb = new StringBuilder();
    
    	foreach (var user in model)
    	{
    		sb.Append("<div class=\"tf_display_box\" align=\"left\">");
    		sb.AppendFormat("<a href=\"#\" class=\"addname\" title=\"{0}\" value=\"{1}\">", user.DisplayName, user.UserId.ToString());
    		sb.Append(user.DisplayName.ToLower().Replace(friendNamePart.ToLower(), string.Format("<b>{0}</b>", friendNamePart.ToLower())));
    		sb.Append("</a><br>");
    		sb.Append("<span style=\"font-size:9px; color:#999999\">");
    		sb.Append(HtmlHelperExtensions.ShowTypeName(user.UserType.ToString()));
    		sb.Append("</span>");
    		sb.Append("</div>");
    	}
    
    	return sb.ToString();
    }
