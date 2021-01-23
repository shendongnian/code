    // Creating the instance..
    Dictionary<string, List<SampleAppNamespace.DisplayAllQuestionsTable>> tPages = 
       new Dictionary<string, List<SampleAppNamespace.DisplayAllQuestionsTable>>();
    
    // putting it into session
    Session["ThreadPage"] = tPages;
    // reading back from session
    tPages = Session["ThreadPage"] as Dictionary<string, List<SampleAppNamespace.DisplayAllQuestionsTable>>;
