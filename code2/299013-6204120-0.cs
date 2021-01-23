    int submitCount = 0;
    if (Session["submitCount"] != null)
    {
        submitCount = int.Parse (Session["submitCount"]);
    }
    // Code based on submitCount
    Session["submitCount"] = ++submitCount; // Save # of submits to session
