       if (Page.IsPostBack)
        {
            string target = Request["__EVENTTARGET"];
            if (target.StartsWith("comment"))
            {
                // remove comment string to get actual id
                string id = target.Replace( "comment", "" );
                
                // now do something with the id, like delete the comment?
            }
        }
        // finish the page
        string theUserId = Session["UserID"].ToString();
        PopulateWallPosts(theUserId);
