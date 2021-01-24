if ((requestCode == PickImageId) && (resultCode == Result.Ok))
{
    if (data.Data == null)
    {
        var clipData = data.ClipData;
        for (int i = 0; i < clipData.ItemCount; i++)
        {
            var item = clipData.GetItemAt(i);
            Android.Net.Uri uri = item.Uri;
            path = GetPathToImage(uri);
            Mesasge(path);
            Finish();
        }
    }
    else
    {
        Android.Net.Uri uri = data.Data;
        path = GetPathToImage(uri);
        Mesasge(path);
        Finish();
    }
}
