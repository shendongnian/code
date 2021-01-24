static void Main(string[] args)
{         
    string   storageAccConnString = "Connection string";
    CloudStorageAccount storageAccount = "Account Name";
    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();       
    CloudBlobContainer container = blobClient.GetContainerReference('files');
    var blobName = "Folder1/Folder2/Folder3" + "myfile.txt";
    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
    Console.WriteLine("URI : " + blockBlob.Uri);
    Console.WriteLine("URI : " + blockBlob.Uri.ToString());
    Console.WriteLine("URI : " + blockBlob.Uri.OriginalString);
    Console.ReadLine();  
    // I didnt write the upload code as my question was regarding URI
}
