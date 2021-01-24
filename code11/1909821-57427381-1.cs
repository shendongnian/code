    private async void InitializeWorks()
            {​
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>​
                {​
                    BackgroundImage.Opacity = 0;​
                    try​
                    {​
                       ​
                        var backgroundImageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets\BackgroundImages");​
                        var backgroundImageFiles = await backgroundImageFolder.GetFilesAsync();​
                        BackgroundImage.Source = new BitmapImage(new Uri(backgroundImageFiles[new Random().Next(0, backgroundImageFiles.Count)].Path));​
                        MyStoryboard.Begin();​
                        MyStoryboard.Completed += MyStoryboard_Completed;​
                    }​
                    catch (Exception e)​
                    {​
                        //​
                    }​
    ​
                });​
    ​
            }
    
    private void MyStoryboard_Completed(object sender, object e)
            {​
                InitializeWorks();​
            }
