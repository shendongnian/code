    ObservableCollection<BitmapFrame> _windowCaptures = new ObservableCollection<BitmapFrame>();
    
    TestWindow testWindow = new TestWindow();
    RenderTargetBitmap bitmap = new RenderTargetBitmap((int)testWindow.Width, (int)testWindow.Height, 96, 96,
                                            PixelFormats.Pbgra32);
    bitmap.Render((Visual)VisualTreeHelper.GetChild(testWindow, 0));
    _windowCaptures.Add(BitmapFrame.Create(bitmap));
    
    <ItemsControl ItemsSource="{Binding}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel></StackPanel>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Image Height="100" Width="100" Source="{Binding}"></Image>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
