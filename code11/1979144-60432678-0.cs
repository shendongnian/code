public bool SetImageFromUrl(string url) {
      var byteArray = new WebClient().DownloadData(url);
      this.projectImage.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
}
public Image projectImage {get; set; }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloaddata?view=netframework-4.8
