    public static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register("ItemSource",
        typeof(ObservableCollection<FileAttachmentModel>), typeof(FileAttachment), new PropertyMetadata(new PropertyChangedCallback(OnChanged));
    //the wrapper property
    public ObservableCollection<FileAttachmentModel> ItemSource
    {
        get { return (ObservableCollection<FileAttachmentModel>)GetValue(ItemSourceProperty); }
        set { SetValue(ItemSourceProperty, value); }
    }
    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        FileAttachment fa = (FileAttachment)d;
        fa.GenerateFileItem(fa.ItemSource);
    }
