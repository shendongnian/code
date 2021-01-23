    PublishingWeb publishingWeb = PublishingWeb.GetPublishingWeb(web);
     
    string pageName = “MyCustomPage.aspx”;
     
    PageLayout[] pageLayouts = publishingWeb.GetAvailablePageLayouts();
     
    PageLayout currPageLayout = pageLayouts[0];
     
    PublishingPageCollection pages = publishingWeb.GetPublishingPages();
     
    PublishingPage newPage = pages.Add(pageName,currPageLayout);
     
    newPage.ListItem[FieldId.PublishingPageContent] = “This is my content”;
     
    newPage.ListItem.Update();
     
    newPage.Update();
     
    newPage.CheckIn(“This is just a comment”);
