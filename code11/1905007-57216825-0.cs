    mockSvc.Setup(svc => svc.IsExistent(It.IsAny<string>(), It.IsAny<string>()))
      .Returns((string bucketName, string blobName) =>
      {
        var isKnownBucket = yourDictionary.TryGetValue(bucketName, out var blobName);
        // more logic here
        return retValue;
      });
