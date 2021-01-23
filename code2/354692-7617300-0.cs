    public class S3Uploader
    {
        private string awsAccessKeyId;
        private string awsSecretAccessKey;
        private string bucketName;
        private Amazon.S3.Transfer.TransferUtility transferUtility;
    
        public S3Uploader(string bucketName)
        {
            this.bucketName = bucketName;
            this.transferUtility = new Amazon.S3.Transfer.TransferUtility("XXXXXXXXXXXXXXXXXX", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
    
        }
    
        public void UploadFile(string filePath, string toPath)
        {
            AsyncCallback callback = new AsyncCallback(uploadComplete);
            var uploadRequest = new TransferUtilityUploadRequest();
            uploadRequest.FilePath = filePath;
            uploadRequest.Key = toPath;
            uploadRequest.AddHeader("x-amz-acl", "public-read");
            transferUtility.BeginUpload(uploadRequest, callback, null);
        }
    
        private void uploadComplete(IAsyncResult result)
        { 
            var x = result;
        }
    }
