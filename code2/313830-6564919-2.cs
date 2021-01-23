    IObservable<BookAction> WhenBookAction()
    {
        return Observable.Defer(() => 
        {
           var menu = ContextMenuFactory.CreateMenu;
           return Observable
             .FromEventPattern<ToolStripItemClickedEventArgs>(
                menu, "ItemClicked")
             .Select(click => GetAction(click.EventArgs.ClickedItem));
        }
    }
