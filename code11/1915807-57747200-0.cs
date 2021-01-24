c#
        private Dictionary<string, string> Images = new Dictionary<string, string>();
        private async void btnLock_Click(object sender, RoutedEventArgs e)
        {
            string path;
            if (Images.TryGetValue(selectedRadioButton.Name, out path))
            {
                StorageFile file = await StorageFile.GetFileFromPathAsync(path);
                await LockScreen.SetImageFileAsync(file);
                try
                {
                    HttpClient httpClient = new HttpClient();
                    Uri uri = new Uri("http://localhost:8080/lock/");
                    
                    HttpStringContent content = new HttpStringContent(
                        "{ \"pass\": \"theMorteza@1378App\" }",
                        UnicodeEncoding.Utf8,
                        "application/json");
                    
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(
                        uri,
                        content);
                    
                    httpResponseMessage.EnsureSuccessStatusCode();
                    var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
private async void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                using (var imageStream = await file.OpenReadAsync())
                {
                    var bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(imageStream);
                    image.Source = bitmapImage;
                }
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                await file.CopyAsync(storageFolder, selectedRadioButton.Name+file.FileType,NameCollisionOption.ReplaceExisting);
                addOrUpdate(selectedRadioButton.Name, Path.Combine(storageFolder.Path, selectedRadioButton.Name + file.FileType));
                save();
            }
        }
        private async void rb_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            selectedRadioButton = rb;
            btnBrowse.IsEnabled = true;
            string path;
            if (Images.TryGetValue(rb.Name, out path))
            {
                StorageFile file = await StorageFile.GetFileFromPathAsync(path);
                using (var imageStream = await file.OpenReadAsync())
                {
                    var bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(imageStream);
                    image.Source = bitmapImage;
                }
            }
        }
        private void addOrUpdate(string key, string image)
        {
            if (Images.Keys.Contains(key))
            {
                Images.Remove(key);
                Images.Add(key, image);
            }
            else
            {
                Images.Add(key, image);
            }
        }
        private async void save()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(Images));
        }
        private async void load()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("sample.txt");
            string fileText = await FileIO.ReadTextAsync(sampleFile);
            try
            {
                Images = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileText);
            }
            catch (Exception)
            {
            }
        }
and you can see in the lock button click event there is a request to a web server cause you **cannot** directly lock the screen in a UWP app and you can follow the rest of your question in my [next answer](https://stackoverflow.com/questions/57737883/problem-using-user32-dll-in-c-sharp-error-1008-an-attempt-was-made-to-reference/57747109#57747109) to the question "why I can't directly lock screen in UWP app?and how to do so?".
