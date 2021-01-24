xml
<Grid>
    <Image x:Name="TestImage" ></Image>
</Grid>
**TestControl.xaml.cs**
csharp
public sealed partial class TestControl : UserControl
{
    public TestControl()
    {
        this.InitializeComponent();
    }
    public byte[] ImageSource
    {
        get { return (byte[])GetValue(ImageSourceProperty); }
        set { SetValue(ImageSourceProperty, value); }
    }
    public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register("ImageSource", typeof(byte[]), typeof(TestControl), new PropertyMetadata(null,new PropertyChangedCallback(Source_Changed)));
    private static async void Source_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue!=null && e.NewValue is byte[] data)
        {
            var instance = d as TestControl;
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(data.AsBuffer());
                await image.SetSourceAsync(stream);
            }
            instance.TestImage.Source = image;
        }
    }
}
**Usage**
xml
<DataTemplate>
    <StackPanel>
        <TestControl Source="{Binding Foto, Mode=TwoWay}"></TestControl>
        <Button Click="Foto_Button_Click">Click me</Button>
    </StackPanel>
</DataTemplate>
Best regards.
