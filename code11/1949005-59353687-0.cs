cs
var fileStream; // file stream you wish to upload to the attachment
var attachmentItem = new AttachmentItem
{
	AttachmentType = AttachmentType.File,
	Name = "flower",
	Size = fileStream.Length
};
await graphClient.Me.Messages[email.Id].Attachments
	.CreateUploadSession(attachmentItem)
	.Request()
	.PostAsync();
2. Create the task using the stream you wish to upload.
cs
// Create task
LargeFileUploadTask<FileAttachment> largeFileUploadTask = new LargeFileUploadTask<FileAttachment>(uploadSession, fileStream);
3. (Optional) You can setup monitoring of the upload progress as by creating an instance of IProgress
cs
// Setup the progress monitoring
IProgress<long> progress = new Progress<long>(progress =>
{
    Console.WriteLine($"Uploaded {progress} bytes of {stream.Length} bytes");
});
4. Upload the attachment to the message!
UploadResult<DriveItem> uploadResult = null;
try
{
    uploadResult = await largeFileUploadTask.UploadAsync(progress);
                    
    if (uploadResult.UploadSucceeded)
    {
        //File attachement uplaod only returns the location URI on successful upload
        Console.WriteLine($"File Uploaded {uploadResult.Location}");//Sucessful Upload
    }
}
catch (ServiceException e)
{
    Console.WriteLine(e.Message);
}
If you query the attachment of the message you should now view the attachement you added without any worries
cs
var attachements = await graphClient.Me.Messages[email.Id].Attachments.Request().GetAsync();
