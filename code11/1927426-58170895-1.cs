cs
private async Task DeleteItems()
{
    // Construct the HTTP Request but DO NOT execute it just yet
    var deleteListItemsRequest = graphServiceClient
        .Sites[siteUrl]
        .Lists[listName]
        .Items
        .Request(deleteQueryOptions);
    // This loop is for iterating over the pages
    do
    {
        // Populate the page by executing the HTTP request
        var deleteListItemsPage = deleteListItemsRequest.GetAsync();
        // Iterate over the current page
        foreach (var listItem in deleteListItemsPage.CurrentPage)
        {
            // Execute the delete and wait for the response
            await graphServiceClient
                .Sites[siteUrl]
                .Lists[listName]
                .Items[deleteItem.Id]
                .Request()
                .DeleteAsync();
        }
        // Check for additional pages
        if (deleteListItemsPage.NextPageRequest != null)
        {
            // If we have an additional page, assign it to the
            // same HTTP Request object. Again, we DO NOT execute 
            // yet. It will get executed at the top of the loop
            deleteListItemsRequest = deleteListItemsPage.NextPageRequest;
        }
        else
        {
            // If we don't have an additional page, set the current
            // request to null so we can use this to trigger an exit
            // from the loop
            deleteListItemsRequest = null;
        }
        // Check if we have a Graph request, if not break out of the loop
    } while (deleteListItemsRequest != null);
}
