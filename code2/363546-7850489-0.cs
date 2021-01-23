    PublishingWeb publishingWeb = null;
    if (PublishingWeb.IsPublishingWeb(web))
    {
        publishingWeb = PublishingWeb.GetPublishingWeb(web); //"web" is your SPWeb, didn't include using statement for your SPSite/SPWeb in this sample
    }
    //assuming your home page is the default, if not - get the correct page here
    SPFile defaultpage = publishingWeb.DefaultPage;
    if (!(defaultpage.CheckOutType == SPFile.SPCheckOutType.None))
    {
       defaultpage.UndoCheckOut();
    }
    defaultpage.CheckOut();
    //Field you want to add HTML in (Alternatively, retreive existing data and modify the HTML)
    defaultpage.ListItemAllFields["PublishingPageContent"] = "string of HTML";
    defaultpage.ListItemAllFields.Update();
    defaultpage.CheckIn("My Comment");
