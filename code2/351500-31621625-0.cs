    private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new Windows.UI.Popups.MessageDialog("Are you sure you want to permanently delete this record?");
            messageDialog.Commands.Add(new UICommand("Yes", (command) =>
            {
                //Do delete
            }));
            messageDialog.Commands.Add(new UICommand("No", (command) =>
            {
                //Do Nothing
            }));
            //default command
            messageDialog.DefaultCommandIndex = 1;
            await messageDialog.ShowAsync();
        }
