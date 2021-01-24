    private async Task LoadItems()
    {
        isLoading = true;
        Title = "Loading";
    
        //simulator delayed load
        Device.StartTimer(TimeSpan.FromSeconds(2), () =>
        {
            for (int i = 0; i < 50; i++)
            {
                Items.Add(string.Format("Item {0}", Items.Count));
            }
            Title = "Done";
            isLoading = false;
            listview.ScrollTo(Items[Items.Count - 1], ScrollToPosition.Start, false);
            //stop timer
            return false;
        });
    }
