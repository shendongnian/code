C#
public async Task CreateFiles(List<MyDataClass> list)
{
  var tasks = list.Select(async item =>
  {
    using (var memorySteam = await _cloudService.DownloadStreamFromCloudAsync(item))
    {
      await Task.Run(() =>
      {
        ReadFile readFile = new ReadFile(memoryStream, new MyFileSerializer());
        readFile.DoWork();
      });
    }
    UpdateTreeViewRecursively();
  });
}
The UI context itself acts as a "lock", so it won't run `UpdateTreeViewRecursively` concurrently.
If the "This may take a while" code degrades the user experience, then you should refactor that method so that either it can offload the slow parts to `Task.Run`, or else use `IProgress<T>` for all its UI updates and run the entire `UpdateTreeViewRecursively` method in a `Task.Run`. Examples:
C#
// Approach using Task.Run within UpdateTreeViewRecursively:
public async Task UpdateTreeViewRecursively()
{
  UpdateSomeTreeViewItem();
  var data = await Task.Run(() => SomeSlowCodeThatDoesNotUpdateUI());
  UpdateSomeOtherTreeViewItem(data);
}
C#
// Approach using IProgress<T>:
public async Task CreateFiles(List<MyDataClass> list)
{
  var tasks = list.Select(async item =>
  {
    using (var memorySteam = await _cloudService.DownloadStreamFromCloudAsync(item))
    {
      await Task.Run(() =>
      {
        ReadFile readFile = new ReadFile(memoryStream, new MyFileSerializer());
        readFile.DoWork();
      });
    }
    var progress = new Progress<MyTreeViewItemUpdate>(update => UpdateSomeTreeViewItem(update));
    await Task.Run(() => UpdateTreeViewRecursively();
  });
}
public void UpdateTreeViewRecursively(IProgress<MyTreeViewItemUpdate> progress)
{
  progress?.Report(new MyTreeViewItemUpdate() { ... });
  var data = SomeSlowCodeThatDoesNotUpdateUI();
  progress?.Report(new MyTreeViewItemUpdate() { ... = data... });
}
