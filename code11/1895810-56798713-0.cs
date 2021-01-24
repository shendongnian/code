ListItem oListItem = oList.GetItemById(3);
   
    // Starting with ClientContext, the constructor requires a URL to the 
    // server running SharePoint. 
    ClientContext context = new ClientContext("http://SiteUrl"); 
    
    // Assume that the web has a list named "Announcements". 
    List announcementsList = context.Web.Lists.GetByTitle("Announcements"); 
    
    // Assume there is a list item with ID=1. 
    ListItem listItem = announcementsList.GetItemById(1); 
    
    // Write a new value to the Body field of the Announcement item.
    listItem["Body"] = "This is my new value!!"; 
    listItem.Update(); 
    
    context.ExecuteQuery();
