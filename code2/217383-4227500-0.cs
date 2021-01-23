    if (e.Key == Key.Delete)
    {
        Dispatcher.BeginInvoke(() =>
        {
            if (HtmlPage.Window.Confirm("r u sure?"))
            {
                //Do stuff....
            }
        }
    }
