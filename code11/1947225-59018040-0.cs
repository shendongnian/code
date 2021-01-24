public MemeBuilder()
{
    InitializeComponent();
    SizeChanged += (s, a) =>
    {
        myLayout.HeightRequest = this.Width;
        myLayout.WidthRequest = this.Width;
    };
    HomePage.SelectedImageCollection.CollectionChanged += AddImageToPreview;
}
private void AddImageToPreview(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                var image = (Image)e.NewItems[e.NewItems.Count - 1];
            }
    ....
}
