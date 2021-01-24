private void AddImage_Click(object sender, EventArgs args)
{
    Intent intent = new Intent();
    intent.SetType("image/*");
    intent.SetAction(Intent.ActionGetContent);
    StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 1);
}
protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
{
    if ((requestCode == 1) && (resultCode == Result.Ok) && (data != null)
    {
        Android.Net.Uri uri = data.Data;
        string path = GetPathToImage(uri);
        Blob.UploadFileInBlob(path);
    }
}
private string GetPathToImage(Android.Net.Uri uri)
{
    ICursor cursor = ContentResolver.Query(uri, null, null, null, null);
    cursor.MoveToFirst();
    string document_id = cursor.GetString(0);
    if (document_id.Contains(":"))
        document_id = document_id.Split(':')[1];
    cursor.Close();
    cursor = ContentResolver.Query(
    MediaStore.Images.Media.ExternalContentUri,
    null, MediaStore.Images.Media.InterfaceConsts.Id + " = ? ", new string[] { document_id }, null);
    cursor.MoveToFirst();
    string path = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Data));
    cursor.Close();
    return path;
}
public class Blob
{
    public static async void UploadFileInBlob(string path)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse("[string here]");
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("[Your container here]");
        await container.CreateIfNotExistsAsync();
        CloudBlockBlob blockBlob = container.GetBlockBlobReference("[Your Blob reference here]");
        await blockBlob.UploadFromFileAsync(path);
    }
}
Note: Be sure to grant **READ_EXTERNAL_STORAGE** under **Required permissions** in the **Android Manifest** through the project properties. Also, enable the **Storage** permission on your device for the app.
