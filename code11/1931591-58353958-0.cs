    [TestMethod]
    [TestCategory("Integration")
    public void DownloadFileFromSender_ConnectionDoesNotGetInterrupted_SuccessfullyDownloadsFile()
    {
       // Arrange - do the setup of files and temp folders, make create sender and receiver
       SetupTestFile(@"Tempfolder\Testfile.txt");
       var sender = new Sender(...);
       var receiver = new Receiver(...);
       sender.ProvideFile(@"Tempfolder\Testfile.txt");
       // Act - Put your actual test here
       var timeBeforeDownload = DateTime.Now;
       receiver.DownloadFile(sender, @"Tempfolder\Testfile.txt", @"Tempfolder\DownloadedFile.txt");
       var totalDownloadTime = DateTime.Now - timeBeforeDownload;
       // Assert - Verify here your assumptions, e.g. download time or file properties
       Assert.IsTrue(totalDownloadTime.TotalMilliseconds < 10000);
       Assert.IsTrue(File.Exists(@"Tempfolder\DownloadedFile.txt"));
    }
