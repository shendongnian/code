cs
public static async Task Move_Directory_Async(
    StorageFolder           sourceDir,
    StorageFolder           destParentDir,
    CreationCollisionOption repDirOpt,
    NameCollisionOption     repFilesOpt)
{
    try
    {
        if (sourceDir == null)
            return;
        List<Task> copies = new List<Task>();
        var files = await sourceDir.GetFilesAsync();
        if (files == null || files.Count == 0)
            await destParentDir.CreateFolderAsync(sourceDir.Name);
        else
        {
            await destParentDir.CreateFolderAsync(sourceDir.Name, repDirOpt);
            foreach (var file in files)
                copies.Add(file.CopyAsync(destParentDir, file.Name, repFilesOpt).AsTask());
        }
        await sourceDir.DeleteAsync(StorageDeleteOption.PermanentDelete);
        await Task.WhenAll(copies);
    }
    catch(Exception ex)
    {
        //Handle any needed cleanup tasks here
        throw new Exception(
          $"A fatal exception triggered within Move_Directory_Async:\r\n{ex.Message}", ex);
    }
}
