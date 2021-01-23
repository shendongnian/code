protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (this.NavigationContext.QueryString.ContainsKey("id"))
    {
        var id = this.NavigationContext.QueryString["id"];
        // TODO: Do what you need to with the ID.
    }
    else
    {
        // I use this condition to handle creating new items.
    }
}
