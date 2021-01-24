    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        Frame currentFrame = Window.Current.Content as Frame;
        MainPage mainPage = currentFrame.Content as MainPage;
        mainPage.UpdateNavigationView(0);
        TasksViewModel viewModel = new TasksViewModel();
        await viewModel.GetData();
        int count = viewModel.searchableTaskTitles.Count();
        bool swapped = false;
        while (swapped == false)
        {
            swapped = true;
            int loopCount = 0;
            System.Diagnostics.Debug.WriteLine(count);
            while (loopCount + 1 != count + 1)
            {
                if (string.Compare(viewModel.searchableTaskTitles.ElementAt(loopCount), viewModel.searchableTaskTitles.ElementAt(loopCount + 1)) == 1)
                {
                    string a = viewModel.searchableTaskTitles[loopCount];
                    viewModel.searchableTaskTitles[loopCount] = viewModel.searchableTaskTitles[loopCount + 1];
                    viewModel.searchableTaskTitles[loopCount + 1] = a;
                    swapped = false;
                }
                loopCount = loopCount + 1;
            }
            loopCount = 0;
        }
    }
