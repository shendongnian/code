C#
object blobs = null;
foreach (IListBlobItem blobItem in container.ListBlobs())
{           
    if (blobItem is CloudBlobDirectory)
    {
        //Console.WriteLine(blobItem.Uri);
        CloudBlobDirectory directory = (CloudBlobDirectory)blobItem;
        blobs = directory.ListBlobs(true);                    
    }
}
///usage:
///(IEnumerable<IListBlobItem>)blobs
