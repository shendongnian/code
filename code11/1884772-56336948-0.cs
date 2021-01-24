    string[] types = { ".jpg", ".png" };
    FileData temp = await CrossFilePicker.Current.PickFile(types);
    if (temp == null)
    {
        return;
    }
    Debug.WriteLine($"ImagePath: {temp.FilePath}");
    Debug.WriteLine($"ImageName: {temp.FileName}");
    //NewEntry.ImagePath = temp.FilePath;
    NewImage = (StreamImageSource)ImageSource.FromStream(() => temp.GetStream());
    
    // Property
    private StreamImageSource _newImage;
    public StreamImageSource NewImage
    {
        get { return _newImage; }
        set
        {
            _newImage = value;
            OnPropertyChanged(nameof(NewImage));
        }
    }
