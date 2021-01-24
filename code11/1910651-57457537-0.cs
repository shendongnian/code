private List<SuggestedItemsInput> GetSuggestedItems()
{
    OHDWebService OHDService = new OHDWebService();
    return OHDService.SaveSuggestedItems(hdnPlainBody.Value, hfdOrderRecordID.Value);
}
private async Task GetSuggestedItemsFromServiceAsync()
{
    List<SuggestedItemsInput> suggestedItems = await Task.Run(() => GetSuggestedItems());
    ViewState["sItems"] = suggestedItems;
    if (suggestedItems != null && suggestedItems.Count > 0)
    {
        GetSuggestedItems(Request["OrderRecordID"].ToString());
        lblInfo.Text = string.Empty;
    }
}
