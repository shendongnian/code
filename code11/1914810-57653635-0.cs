    protected async void btnClaim_Click(object sender, EventArgs e)
        {
            await GetSuggestedItemsFromService();
        }
    
        private async Task GetSuggestedItemsFromService()
        {
            List<SuggestedItemsInput> suggestedItems = await Task.Run(() => SaveAndGetSuggestedItemAsync());
    
            ViewState["sItems"] = suggestedItems;
            if (suggestedItems != null && suggestedItems.Count > 0)
            {
                GetSuggestedItems(Request["OrderRecordID"].ToString());
                lblInfo.Text = string.Empty;
            }
        }
    // Rest of your code
