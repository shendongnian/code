    ShowImageCommand = new RelayCommand<Image>(ShowImageMethod);
    ...
    public void ShowImageMethod(Image image)
    {
        ImageWindow win2 = new ImageWindow(image.Name);
        win2.Show();
    }
