    private void UploadFileToS3(string filePath)
    {
	    var awsAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
	    var awsSecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];
	    var existingBucketName = ConfigurationManager.AppSettings["AWSBucketName"];
	    var client = Amazon.AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey,RegionEndpoint.USEast1);
    
    	var uploadRequest = new TransferUtilityUploadRequest
    	{
		    FilePath = filePath,
		    BucketName = existingBucketName,
		    CannedACL = S3CannedACL.PublicRead
	    };
    	
    var fileTransferUtility = new TransferUtility(client);
    	fileTransferUtility.Upload(uploadRequest);
    } 
