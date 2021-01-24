[TestClass]
public class StoreServiceTest
{
	Mock<IAccess> mockAccess;
	Mock<IAccess> mockAccessNoData;
	Mock<IDataReader> mockReader;
	Mock<IDataReader> mockReaderNoData;
	Mock<IStoreService> mockStoreService;
And then on the `TestInitiailize`, I `Setup` the default implementation as follows:
mockReader = new Mock<IDataReader>();
mockReader.Setup(m => m.IsDBNull(It.IsAny<int>())).Returns(false);
mockReader.Setup(m => m.GetString(It.IsAny<int>())).Returns("stub");
mockReader.Setup(m => m.GetBoolean(It.IsAny<int>())).Returns(true);
mockReader.Setup(m => m.GetInt32(It.IsAny<int>())).Returns(32);
mockReader.SetupSequence(m => m.Read()).Returns(true).Returns(false); // setup sequence to avoid infinite loop
mockAccess = new Mock<IAccess>();
mockAccess.Setup(m => m.ReadData(It.IsAny<string>(), It.IsAny<object[]>())).Returns(mockReader.Object);
mockReaderNoData = new Mock<IDataReader>();
mockReaderNoData.Setup(m => m.Read()).Returns(false);
mockAccessNoData = new Mock<IAccess>();
mockAccessNoData.Setup(m => m.ReadData(It.IsAny<string>(), It.IsAny<object[]>())).Returns(mockReaderNoData.Object);
mockStoreService = new Mock<IStoreService>(); 
And now for a default kind of test, all I do is pass the `mockReader.Object` which should have the default implementation since every test begins with `TestInitialize`, and then for a special case, say I want to return `"sub"` instead of `"stub"` for `IDataReader`'s `GetString()` method, I can do something like this:
mockReader.Setup(m => m.GetString(It.IsAny<int>())).Returns((int col) => {
	if (col == 2) return "sub";
	else return "stub";
});
Hope that helps!
