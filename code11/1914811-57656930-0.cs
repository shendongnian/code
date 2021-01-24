    protected void btnClaim_Click(object sender, EventArgs e)
    {
        RegisterAsyncTask(GetSuggestedItemsFromService);
    }
    private async Task GetSuggestedItemsFromService()
    {
        List<SuggestedItemsInput> suggestedItems = await SaveAndGetSuggestedItemAsync();
        ViewState["sItems"] = suggestedItems;
        if (suggestedItems != null && suggestedItems.Count > 0)
        {
            GetSuggestedItems(Request["OrderRecordID"].ToString());
            lblInfo.Text = string.Empty;
        }
    }
