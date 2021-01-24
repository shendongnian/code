    var dynamoDb = A.Fake<IAmazonDynamoDb>();
    A.CallTo(() => dynamoDb.ScanAsync(A<ScanRequest>._, A<CancellationToken>._))
        .Returns(new ScanResponse
        {
            // Define the ScanResponse you want the method to return
            ...
        });
