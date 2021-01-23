    PublishingWeb pw = null;
    //"web" is your SPWeb, didn't include using statement for your SPSite/SPWeb in this sample
    if (PublishingWeb.IsPublishingWeb(web))
    {
        pw = PublishingWeb.GetPublishingWeb(web); 
    }
    //todo: add some handling here for if web is not a publishingWeb
    //assuming your home page is the default, if not - get the correct page here
    SPFile defaultpage = pw.DefaultPage;
    if (!(defaultpage.CheckOutType == SPFile.SPCheckOutType.None))
    {
       //programatically creating this stuff, so cancel any unexpected checkouts
       defaultpage.UndoCheckOut();
    }
    defaultpage.CheckOut();
    //Field you want to add HTML in (Alternatively, retreive existing data and modify the HTML)
    defaultpage.ListItemAllFields["PublishingPageContent"] = "string of HTML";
    defaultpage.ListItemAllFields.Update();
    defaultpage.CheckIn("My Comment");
