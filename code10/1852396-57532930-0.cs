cs
public static async Task Move_Directory_Async(
    StorageFolder           sourceDirectory,
    StorageFolder           destinationParentDirectory,
    CreationCollisionOption replaceDirectoryOption,
    NameCollisionOption     replaceFilesOption)
{
    try
    {
        if (sourceDirectory == null)
            return;
        List<Task> copies = new List<Task>();
        var files = await sourceDirectory.GetFilesAsync();
        if (files == null || files.Count == 0)
            await destinationParentDirectory.CreateFolderAsync(sourceDirectory.Name);
        else
        {
            await destinationParentDirectory.CreateFolderAsync(sourceDirectory.Name, replaceDirectoryOption);
            foreach (var file in files)
                copies.Add(file.CopyAsync(destinationParentDirectory, file.Name, replaceFilesOption).AsTask());
        }
        await sourceDirectory.DeleteAsync();
        await Task.WhenAll(copies);
    }
    catch(Exception ex)
    {
        //Handle any needed cleanup tasks here
        throw new Exception($"A fatal exception triggered within Move_Directory_Async:\r\n{ex.Message}", ex);
    }
}
