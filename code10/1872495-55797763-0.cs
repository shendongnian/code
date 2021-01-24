C#
private readonly Channel<string> _contrastValue = Channel.CreateBounded<string>(new BoundedChannelOptions
{
  Capacity = 1,
  FullMode = BoundedChannelFullMode.DropOldest,
});
// You'll need to start this consumer somewhere and observe it (via await) to ensure you see exceptions
private async Task ConsumeContrastValueAsync()
{
  var reader = _contrastValue.Reader;
  while (await reader.WaitToReadAsync(CancellationToken.None))
    while (reader.TryRead(out var value))
      await _PlayerList[0].UpdateVideoFilter("eq=contrast=" + value);
}
private async void TbeVolumeLevel_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
{
  await _contrastValue.Writer.WriteAsync(e.NewValue.ToString(), CancellationToken.None);
}
  [1]: https://www.nuget.org/packages/System.Threading.Channels/
