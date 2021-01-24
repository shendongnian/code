csharp
public async Task SaveList(List<TestModel> list)
{
    string json = JsonConvert.SerializeObject(list);
    var localFolder = ApplicationData.Current.LocalFolder;
    var saveFile = await localFolder.CreateFileAsync("SaveList.json", CreationCollisionOption.OpenIfExists);
    await FileIO.WriteTextAsync(saveFile, json);
}
Best regards.
