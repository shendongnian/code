private readonly Command textChangedCommand = new Command(TextChanged);
private void TextChanged(object searchingText)
{
    if( searchingText is String s )
    {
        this.Items = this.ConstItems
            .Where( x => x.Surname.IndexOf( s, StringComparison.CurrentCultureIgnoreCase ) > -1 )
            .ToList()
    } 
}
