public void SaveUser(SearchRolesViewModel objSearchRolesViewModel, string userID)
        {
           DirectoryEntry de = new DirectoryEntry();
                de = QueryAD(objSearchRolesViewModel.NID); // <--- This is the issue.
...
Look up DirectoryEntry from the QueryAD function and return that object to make your call work.
public string QueryAD(string userNID) // You will need to return DirectoryEntry to make your code work.
        {
            DirectorySearcher ds = new DirectorySearcher
