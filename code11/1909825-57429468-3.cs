        private async void InitializeFrontWorks()
        {
            // Animations
            DispatcherTimer dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            var backgroundImageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets\BackgroundImages");
            var backgroundImageFiles = await backgroundImageFolder.GetFilesAsync();
            AnimationBackgroundImage(backgroundImageFiles);
            dispatcherTimer.Tick += delegate
            {
                AnimationBackgroundImage(backgroundImageFiles);
            };
            dispatcherTimer.Start();
        }
        private void AnimationBackgroundImage(IReadOnlyList<StorageFile> backgroundImageFiles)
        {
            BackgroundImageStoryboardDecrease.Begin();
            BackgroundImageStoryboardDecrease.Completed += delegate
            {
                BackgroundImage.Source = new BitmapImage(new Uri(backgroundImageFiles[new Random().Next(0, backgroundImageFiles.Count)].Path));
                BackgroundImageStoryboardIncrease.Begin();
            };
        }
