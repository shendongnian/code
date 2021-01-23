    Google.GData.Documents.DocumentsService service = new Google.GData.Documents.DocumentsService("YOUR_APPLICATIONS_NAME");
    service.setUserCredentials("YOUR_USERNAME", "YOUR_PASSWORD");
    
    Google.GData.Documents.SpreadsheetQuery query = new Google.GData.Documents.SpreadsheetQuery();
    query.Title = "YOUR_SPREADSHEETS_TITLE";
    query.TitleExact = true;
    
    Google.GData.Documents.DocumentsFeed feed = service.Query(query);
    Google.GData.Client.AtomEntry entry = feed.Entries[0];
    
    var feedUri = new Uri(Google.GData.Documents.DocumentsListQuery.documentsBaseUri);
    
    service.Insert(feedUri, entry);
