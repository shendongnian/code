private string AHKoutput;
foreach (var menu in resultingMessage.MenuItem)
{
  Recurse(menu, menu.name);
}
private void Recurse(MenuItem menuit, string title)
{
    if (menuit.AHKEntry != null && menuit.AHKEntry.Any())
    {
        foreach (var ahk in menuit.AHKEntry)
        {
            AHKoutput = AHKoutput + (title);
        }
    }
    if (menuit.MenuItem1 != null && menuit.MenuItem1.Any())
    {
        foreach (var menuItem in menuit.MenuItem1)
        {
            Recurse(menuItem, title + "..." + menuItem.name);
        }
    }
}
