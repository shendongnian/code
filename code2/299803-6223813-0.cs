    public interface IFileDataSource {
        string ReadAllText(string s);
    }
    [Test]
    public void TestName() {
        int fileReadCount = 0;
        var fs = Substitute.For<IFileDataSource>();
        fs.ReadAllText("test").ReturnsForAnyArgs(x =>
           {
               fileReadCount++;
               return "test";
           });
        fs.ReadAllText("sdf");
        fs.ReadAllText("sdf");
        Assert.AreEqual(fileReadCount, 2);
    }
