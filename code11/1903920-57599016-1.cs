    public async void Load()
    {
        var picker = new FileOpenPicker()
        {
            SuggestedStartLocation = PickerLocationId.PicturesLibrary,
            FileTypeFilter = { ".jpg", ".jpeg", ".png", ".bmp" },
        };
    
        ((IInitializeWithWindow)(object)picker).Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);    
    
        var file = await picker.PickSingleFileAsync();
        if (file != null)
        {
    
        }
        else
        {
    
        }
    }
