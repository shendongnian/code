csahrp
public class ImageItem
{
    public string Name { get; set; }
    public BitmapImage Image { get; set; } = null;
    public ImageItem()
    {
    }
    public async Task Init()
    {
        // do somethings..
        // get image from folder, named imageFile
        Image = new BitmapImage();
        await Image.SetSourceAsync(await imageFile.OpenReadAsync());
    }
}
-ImageItemControl.xaml
xml
<UserControl
    ...>
    <StackPanel>
        <Image Width="200" Height="200" x:Name="MyImage"/>
    </StackPanel>
</UserControl>
-ImageItemControl.xaml.cs
csharp
public sealed partial class ImageItemControl : UserControl
{
    public ImageItemControl()
    {
        this.InitializeComponent();
    }
    public ImageItem Data
    {
        get { return (ImageItem)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(ImageItem), typeof(ImageItemControl), new PropertyMetadata(null,new PropertyChangedCallback(Data_Changed)));
    private static async void Data_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue != null)
        {
            var image = e.NewValue as ImageItem;
            var instance = d as ImageItemControl;
            if (image.Image == null)
            {
                await image.Init();
            }
            instance.MyImage.Source = image.Image;
        }
    }
}
-Usage
xml
<Page.Resources>
    <DataTemplate x:DataType="local:ImageItem" x:Key="ImageTemplate">
        <controls:ImageItemControl Data="{Binding}"/>
    </DataTemplate>
</Page.Resources>
<Grid>
    <GridView ItemTemplate="{StaticResource ImageTemplate}"
              .../>
</Grid>
> Please modify this code according to your actual situation
There are some advantages to this. Through the distributed method, on the one hand, the loading speed of pictures is increased (simultaneous loading). On the other hand, with virtualization, some pictures are not actually rendered, which can reduce memory usage.
**2. Limiting the resolution of `BitmapImage`**
This is very important, it can greatly reduce the memory consumption when loading a large number of pictures.
For example, you have a picture with 1920x1080 resolution, but only 200x200 resolution is displayed on the application. Then loading the original image will waste system resources.
We can modify the `ImageItem.Init` method:
csharp
public async Task Init()
{
    // do somethings..
    // get image from folder, named imageFile
    Image = new BitmapImage() { DecodePixelWidth = 200 };
    await Image.SetSourceAsync(await imageFile.OpenReadAsync());
}
Hope these two methods can help you reduce memory usage.
Best regards.
