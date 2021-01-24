    public class MySpaceManagerTests
    {
      // First simple, best good path for code
      public void TryDeleteAllFiles2_WithEmptyPath_ThrowsNoException()
      {
        /// ** ASSIGN **
        // I'm using NSubstitute here just for an example
        // could use Moq or RhinoMocks, whatever doesn't  
        // really matter in this instance
        // the important part is that we do NOT test dependencies
        // the class relies on.
        var fileManager = Substitute.For<IFileManager>();
        fileManager
          .GetFiles(Args.Any<string>())
          .Returns(new List<IFile>());
        var mySpaceManager = new MySpaceManager(fileManager);
        // ** ACT && ASSERT**
        // we know that the argument doesn't matter so we don't need it to be
        // anything at all, we just want to make sure that it runs to completion
        Asser.DoesNotThrow(() => mySpaceManager.TryDeleteAllFiles2(string.Empty);
      }
      // This looks VERY similar to the first test but
      // because the assert is different we need to write a different
      // test.  Each test should only really assert the name of the test
      // as it makes it easier to debug and fix it when it only tests
      // one thing.
      public void TryDeleteAllFiles2_WithEmptyPath_CallsFileManagerGetFiles()
      {
        /// ** ASSIGN **
        var fileManager = Substitute.For<IFileManager>();
        fileManager
          .GetFiles(Args.Any<string>())
          .Returns(new List<IFile>());
        var mySpaceManager = new MySpaceManager(fileManager);
        // ** ACT **
        mySpaceManager.TryDeleteAllFiles2(string.Empty)
        // ** ASSERT **
        Assert.DoesNotThrow(fileManager.Received().GetFiles());
      }
      public void TryDeleteAllFiles2_With0Files_DoesNotCallDeleteFile
      {
        /// ** ASSIGN **
        var fileManager = Substitute.For<IFileManager>();
        fileManager
          .GetFiles(Args.Any<string>())
          .Returns(new List<IFile> { Substitute.For<IFile>(); });
        var mySpaceManager = new MySpaceManager(fileManager);
        // ** ACT **
        mySpaceManager.TryDeleteAllFiles2(string.Empty)
        // ** ASSERT **
        Assert.DoesNotThrow(fileManager.DidNotReceive().GetFiles());
      }
      public void TryDeleteAllFiles2_With1File_CallsFileManagerDeleteFile
      {
        // etc
      }
      public void TryDeleteAllFiles2_With1FileDeleted_ReturnsTrue()
      {
        /// ** ASSIGN **
        var fileManager = Substitute.For<IFileManager>();
        fileManager
          .GetFiles(Args.Any<string>())
          .Returns(new List<IFile> { Substitute.For<IFile>(); }, 
            new list<IFile>());
        var mySpaceManager = new MySpaceManager(fileManager);
        // ** ACT **
        var actual = mySpaceManager.TryDeleteAllFiles2(string.Empty)
        // ** ASSERT **
        Assert.That(actual, Is.True);
      }
      public void TryDeleteAllFiles2_With1FileNotDeleted_ReturnsFalse()
      {
        /// ** ASSIGN **
        var fileManager = Substitute.For<IFileManager>();
        fileManager
          .GetFiles(Args.Any<string>())
          .Returns(new List<IFile> { Substitute.For<IFile>(); }, 
            new List<IFile> { Substitute.For<IFile>(); });
        var mySpaceManager = new MySpaceManager(fileManager);
        // ** ACT **
        var actual = mySpaceManager.TryDeleteAllFiles2(string.Empty)
        // ** ASSERT **
        Assert.That(actual, Is.False);
      }
    }
