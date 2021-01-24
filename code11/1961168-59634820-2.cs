csharp
static class ImageService
{
    static readonly HttpClient _client = new HttpClient();
    public static Task<byte[]> DownloadImage(string imageUrl)
    {
        if (!imageUrl.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
            throw new Exception("iOS and Android Require Https");
        return _client.GetByteArrayAsync(imageUrl);
    }
}
# Step 2 Save Image to Disk
Now that we've downloaded the image, we will save it to disk.
`Xamarin.Essentials.Preferences` allows us to save items to disk using key-value pairs, so we'll have to first convert the `byte[]` to a Base64 string before saving it to disk.
csharp
static class ImageService
{
    static readonly HttpClient _client = new HttpClient();
    public static Task<byte[]> DownloadImage(string imageUrl)
    {
        if (!imageUrl.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
            throw new Exception("iOS and Android Require Https");
        return _client.GetByteArrayAsync(imageUrl);
    }
    public static void SaveToDisk(string imageFileName, byte[] imageAsBase64String)
    {
        Xamarin.Essentials.Preferences.Set(imageFileName, Convert.ToBase64String(imageAsBase64String));
    }
}
## Step 3 Retrieve the Image for Display
Now that we've downloaded the image and saved it to disk, we need to be able to retrieve the image from disk to display it on the screen.
`GetFromDisk` below retrieves the image from disk and converts it to `Xamarin.Forms.ImageSource`.
csharp
static class ImageService
{
    static readonly HttpClient _client = new HttpClient();
    public static Task<byte[]> DownloadImage(string imageUrl)
    {
        if (!imageUrl.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
            throw new Exception("iOS and Android Require Https");
        return _client.GetByteArrayAsync(imageUrl);
    }
    public static void SaveToDisk(string imageFileName, byte[] imageAsBase64String)
    {
        Xamarin.Essentials.Preferences.Set(imageFileName, Convert.ToBase64String(imageAsBase64String));
    }
    public static Xamarin.Forms.ImageSource GetFromDisk(string imageFileName)
    {
        var imageAsBase64String = Xamarin.Essentials.Preferences.Get(imageFileName, string.Empty);
        return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(imageAsBase64String)));
    }
}
## Example: Using ImageService in a Xamarin.Forms.ContentPage
csharp
class MyPage : ContentPage
{
    readonly Image _downloadedImage = new Image();
    public MyPage()
    {
        Content = _downloadedImage;
    }
    protected override  async void OnAppearing()
    {
        var downloadedImage = await ImageService.DownloadImage("https://cdn.dribbble.com/users/3701/screenshots/5557667/xamarin-studio-1_2x_4x.png");
        ImageService.SaveToDisk("XamarinLogo.png", downloadedImage);
        _downloadedImage.Source = ImageService.GetFromDisk("XamarinLogo.png");
    }
}
