     private async void SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            int itemIndex = myList.SelectedIndex;
            //checking if the selected index is -1 (or no item is actually selected)
            if (itemIndex != -1)
            {
                var messageDialog = new MessageDialog("What do you want to do?", "Alert!");
                messageDialog.Commands.Add(new UICommand("Do It", null));
                messageDialog.Commands.Add(new UICommand("Don't do it", null));
                messageDialog.Commands.Add(new UICommand("Cancel", null));
                var cmdClick = await messageDialog.ShowAsync();
                Debug.WriteLine(itemIndex);
                if (cmdClick.Label == "Do It")
                {
                    Debug.WriteLine("Do It");
                    myList.Items.RemoveAt(itemIndex);
                    return;
                }
                if (cmdClick.Label == "Don't do it")
                {
                    Debug.WriteLine("No defect");
                    myList.Items.RemoveAt(itemIndex);
                    return;
                }
                if (cmdClick.Label == "Cancel")
                {
                    Debug.WriteLine("Cancel");
                    return;
                }
            }
        }
