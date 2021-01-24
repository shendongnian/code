    using MailChimp.Net;
    
    private async Task MaintainTagsAsync()
    {
        string apikey = "<apikey>";
        string listid = "<listid>";
        string emailaddress = "x@x.com";
    
        try {
          MailChimpManager Mcm = new MailChimpManager(apikey);
          Member m = await Mcm.Members.GetAsync(listid, emailaddress);
    	  Tags tags = new Tags();
    	  tags.MemberTags.Add(new Tag() {
    			Name = "MyTag",
    			Status = "active"
    	  });
    	  await Mcm.Members.AddTagsAsync(listId, emailaddress, tags);
        }
        catch (Exception e) {}
    }
