    public class MyCustomMenuHandler : IContextMenuHandler
    {
    public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
    {
        // Remove any existent option using the Clear method of the model
        //
        //model.Clear();
        Console.WriteLine("Context menu opened !");
        // You can add a separator in case that there are more items on the list
        if (model.Count > 0)
        {
            model.AddSeparator();
        }
        // Add a new item to the list using the AddItem method of the model
        model.AddItem((CefMenuCommand)26501, "Show DevTools");
        // Add a separator
        model.AddSeparator();
        model.AddItem((CefMenuCommand)26503, "Open in Paintbrush");
        model.AddItem((CefMenuCommand)26504, "Open in Excel");
        model.AddItem((CefMenuCommand)26505, "Run Script..");
