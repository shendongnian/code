public void SaveUser(SearchRolesViewModel objSearchRolesViewModel, string userID)
        {
           DirectoryEntry de = new DirectoryEntry();
                de = QueryAD(objSearchRolesViewModel.NID); // <--- This is the issue.
...
Look up DirectoryEntry from the QueryAD function and return that object to make your call work.
public string QueryAD(string userNID) // You will need to return DirectoryEntry to make your code work.
        {
            DirectorySearcher ds = new DirectorySearcher
EDIT:
Change your QueryAD method to following
public DirectoryEntry QueryAD(string userNID) // UPDATE RETURN TYPE HERE TO DIRECTORYENTRY
        {
            DirectorySearcher ds = new DirectorySearcher
            {
                SearchRoot = new DirectoryEntry(""),
                //start searching from local domain
                Filter = userNID
            };
            ds.PropertiesToLoad.Add("givenname");
            ds.PropertiesToLoad.Add("sn");
            ds.PropertiesToLoad.Add("mail");
            // start searching
            SearchResultCollection searchCollection = ds.FindAll();
            try
            {
            foreach (SearchResult result in searchCollection)
                {
                    if (result != null)
                        return result as DirectoryEntry; 
                }
                return "Unkown User";
                ...
