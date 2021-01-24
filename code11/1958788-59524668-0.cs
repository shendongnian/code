csharp
public async static Task<StorageFile> OpenLocalFile(params string[] types)
{
    var picker = new FileOpenPicker();
    picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
    Regex typeReg = new Regex(@"^\.[a-zA-Z0-9]+$");
    foreach (var type in types)
    {
        if (type == "*" || typeReg.IsMatch(type))
            picker.FileTypeFilter.Add(type);
        else
            throw new InvalidCastException("File extension is incorrect");
    }
    var file = await picker.PickSingleFileAsync();
    if (file != null)
        return file;
    else
        return null;
}
**Usage**
csharp
var file = await OpenLocalFile(".jpg");
var bytes = (await FileIO.ReadBufferAsync(file)).ToArray();
Best regards.
