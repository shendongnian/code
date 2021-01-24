xml
 <StackPanel>
     <Image Name="MyImage"/>
     <TextBlock Name="MyDescription"/>
 </StackPanel>
**Code Behind**
csharp
public sealed partial class ImagePage : Page
{
    public ImagePage()
    {
        this.InitializeComponent();
    }
 
    public class ImageModel
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter != null && e.Parameter is ImageModel)
        {
            var data = e.Parameter as ImageModel;
            MyImage.Source = new BitmapImage(new Uri(data.ImageUrl));
            MyDescription.Text = data.Description;
        }
    }
 
}
Then add Frame that use to navigate On the Main page.
xml
<Grid>
  <Frame Name="ImageFrame"/>
</Grid>
**Usage**
csharp
public MainPage()
{
  this.InitializeComponent();
  var TestData=new ImageModel
  { 
    ImageUrl = "https://via.placeholder.com/150", 
    Description = "This is a test image"
  }
 
  ImageFrame.Navigate( typeof(ImagePage), TestData );
}
Now, when you start the application, your new image page will load in the frame.
This is a short example, the main purpose is to express how to jump to the page and give parameters to the page. 
When the page receives a parameter, you can adjust the UI according to the parameter.
So, you can use the GridView to display all the images. When you click on one of them, use this principle to jump to the pre-designed page.
I hope this can help you.
