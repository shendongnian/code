csharp
public class ImageModel
{
    public string ImageUrl { get; set; }
    // Other properties
    ...
}
2. In the code-behind file of the page, create a new collection and fill the data:
csharp
// ObservableCollection can notify UI when collection item changed
public ObservableCollection<ImageModel> ImageCollection = new ObservableCollection<ImageModel>();
public TestImagePage()
{
    this.InitializeComponent();
    ImageInit();
}
public void ImageInit()
{
    // Load image model here.
    // e.g.
    ImageCollection.Add(new ImageModel{ImageUrl="ms-appx:///Assets/image.png"});
}
3. Create DataTemplate and GridView on XAML:
xml
<Page
    ...>
    <Grid>
        <GridView ItemsSource="{x:Bind ImageCollection}">
            <GridView.ItemTemplate>
                <DataTemplate x:DataType="local:ImageModel">
                    <Image Opacity="0.4"
                       MaxWidth="500"
                       MaxHeight="500"
                       Source="{x:Bind ImageUrl}"
                       />
                </DataTemplate>
            </GridView.ItemTemplate>
        </GridView>
    </Grid>
</Page>
The process I provide is very simple, you can expand this code according to your needs.
Best regards.
