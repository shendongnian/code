    private void SQLQueryListView_OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        var param = (SQLQuery)e.Query;
        if (((ViewModel)BindingContext).RunQueryCommand.CanExecute(param))
        {
            ((ViewModel)BindingContext).RunQueryrCommand.Execute(param);
        }
    }
