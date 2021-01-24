public static void ProcessQueueMessage([QueueTrigger("%testQueue%")],
TestMessageModel testMessage,
[Blob("testStorage")] CloudBlobContainer blobContainer)
{
   CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(testmessage.id+".txt");
}
