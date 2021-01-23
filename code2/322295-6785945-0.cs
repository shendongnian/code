foreach (var item in Files)
{
    if (item.IsChecked)
        if (storage.FileExists(item.FileName))
        {
           storage.DeleteFile(item.FileName);
           readItems.Add(item);
        }
}
</pre>
