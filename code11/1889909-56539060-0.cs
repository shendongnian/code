                    if (Device.RuntimePlatform == Device.Android)
                    {
                       FileData fileData = await CrossFilePicker.Current.PickFile();
                        if (fileData == null)
                            return; // user canceled file picking
                      var filepath = fileData.FilePath;
                        
                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    {
                        var isInitialized = await CrossMedia.Current.Initialize();
                        var isPickPhotoSupported = CrossMedia.Current.IsPickPhotoSupported;
                        var file = await CrossMedia.Current.PickPhotoAsync();
                        if (file == null)
                        {
                            return;
                        }
                        var filePath = file.Path;
                    }
                    
