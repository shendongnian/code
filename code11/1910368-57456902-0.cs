csharp
public class CustomTileDataSource : CustomMapTileDataSource
{
    private string _tileUrl;
    public Dictionary<string, string> AdditionalRequestHeaders = new Dictionary<string, string>();
    private Dictionary<string, string> DefaultRequestHeaders = new Dictionary<string, string>();
    public CustomTileDataSource(string tileUrl)
    {
        _tileUrl = tileUrl;
        DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
        DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7");
        DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
        DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
        DefaultRequestHeaders.Add("User-Agent", "ozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.10 Safari/537.36 Edg/77.0.235.5");
        BitmapRequested += BitmapRequestedHandler;
    }
    private async void BitmapRequestedHandler(CustomMapTileDataSource sender, MapTileBitmapRequestedEventArgs args)
    {
        var deferral = args.Request.GetDeferral();
        try
        {
            using (var imgStream = await GetTileAsStreamAsync(args.X, args.Y, args.ZoomLevel))
            {
                var memStream = imgStream.AsRandomAccessStream();
                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(memStream);
                var pixelProvider = await decoder.GetPixelDataAsync(Windows.Graphics.Imaging.BitmapPixelFormat.Rgba8, Windows.Graphics.Imaging.BitmapAlphaMode.Straight, new Windows.Graphics.Imaging.BitmapTransform(), Windows.Graphics.Imaging.ExifOrientationMode.RespectExifOrientation, Windows.Graphics.Imaging.ColorManagementMode.ColorManageToSRgb);
                var pixels = pixelProvider.DetachPixelData();
                var width = decoder.OrientedPixelWidth;
                var height = decoder.OrientedPixelHeight;
                Parallel.For(0, height, i =>
                {
                    for (int j = 0; j <= width - 1; j++)
                    {
                        // Alpha channel Index (RGBA) 
                        var idx = (i * height + j) * 4 + 3;
                    }
                });
                var randomAccessStream = new InMemoryRandomAccessStream();
                var outputStream = randomAccessStream.GetOutputStreamAt(0);
                var writer = new DataWriter(outputStream);
                writer.WriteBytes(pixels);
                await writer.StoreAsync();
                await writer.FlushAsync();
                args.Request.PixelData = RandomAccessStreamReference.CreateFromStream(randomAccessStream);
            }
        }
        catch
        {
        }
        deferral.Complete();
    }
    private Task<MemoryStream> GetTileAsStreamAsync(int x, int y, int zoom)
    {
        var tcs = new TaskCompletionSource<MemoryStream>();
        var quadkey = TileXYZoomToQuadKey(x, y, zoom);
        string url;
        url = _tileUrl.Replace("{x}", x.ToString()).Replace("{y}", y.ToString()).Replace("{zoomlevel}", zoom.ToString()).Replace("{quadkey}", quadkey);
        var request = WebRequest.Create(url);
        foreach (var defaultHeader in DefaultRequestHeaders)
        {
            request.Headers.Add(defaultHeader.Key, defaultHeader.Value);
        }
        if (AdditionalRequestHeaders.Count > 0)
        {
            foreach (var addHeader in AdditionalRequestHeaders)
            {
                request.Headers.Add(addHeader.Key, addHeader.Value);
            }
        }
        request.BeginGetResponse(async a =>
        {
            var r = (HttpWebRequest)a.AsyncState;
            HttpWebResponse response = (HttpWebResponse)r.EndGetResponse(a);
            using (var s = response.GetResponseStream())
            {
                var ms = new MemoryStream();
                await s.CopyToAsync(ms);
                ms.Position = 0;
                tcs.SetResult(ms);
            }
        }, request);
        return tcs.Task;
    }
    private string TileXYZoomToQuadKey(int tileX, int tileY, int zoom)
    {
        var quadKey = new StringBuilder();
        for (int i = zoom; i >= 1; i += -1)
        {
            char digit = '0';
            int mask = 1 << (i - 1);
            if ((tileX & mask) != 0)
                Strings.ChrW(Strings.AscW(digit) + 1);
            if ((tileY & mask) != 0)
            {
                Strings.ChrW(Strings.AscW(digit) + 1);
                Strings.ChrW(Strings.AscW(digit) + 1);
            }
            quadKey.Append(digit);
        }
        return quadKey.ToString();
    }
    private void TileXYZoomToBBox(int x, int y, int zoom, ref double north, ref double south, ref double east, ref double west)
    {
        double mapSize = Math.Pow(2, zoom);
        west = ((x * 360) / mapSize) - 180;
        east = (((x + 1) * 360) / mapSize) - 180;
        double efactor = Math.Exp((0.5 - y / mapSize) * 4 * Math.PI);
        north = (Math.Asin((efactor - 1) / (efactor + 1))) * (180 / Math.PI);
        efactor = Math.Exp((0.5 - (y + 1) / mapSize) * 4 * Math.PI);
        south = (Math.Asin((efactor - 1) / (efactor + 1))) * (180 / Math.PI);
    }
}
**Usage**
csharp
var dataSource = new CustomTileDataSource("https://tile.openstreetmap.org/{zoomlevel}/{x}/{y}.png");
dataSource.AdditionalRequestHeaders.Add("header_name", "header_value");
// other code
var mySource = new MapTileSource(dataSource);
myMap.TileSources.Add(mySource);
During the test, I also encountered the problem that `HttpMapTileDataSource.AdditionalRequestHeaders` does not display. I tried to use `CustomMapTileDataSource` to derive and rewrite the related methods so that it can work normally.
The reason for saying that it is a semi-finished product is that it does not establish a good caching mechanism, and the initial loading time is very long.
Best regards.
