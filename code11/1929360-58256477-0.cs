    private void onClick(object sender, RoutedEventArgs e)
    {
        /// Now, I want to change the Label's content.
        myLabel2.Content = "label changed"; /// O.K.
        var my_widgetItem = myContentPresenter.Content as Widget;
        my_widgetItem.Title2 = "new content after click";
    }
