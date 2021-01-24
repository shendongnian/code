    //....
    var stream = new MemoryStream();
    var writer = new StreamWriter(stream);
    writer.Write("sample data");
    writer.Flush();
    stream.Position = 0;
    var blobMock = new Mock<CloudBlockBlob>(new Uri("http://tempuri.org/blob"));
    blobMock
        .Setup(m => m.ExistsAsync())
        .ReturnsAsync(true);
    blobMock
        .Setup(m => m.DownloadToStreamAsync(It.IsAny<MemoryStream>()))
        .Callback((Stream target) => stream.CopyTo(target)) //<---Something like this
        .Returns(Task.CompletedTask);
    //....
