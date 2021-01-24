c#
using Moq;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;
c#
[TestInitialize]
public void InitTest()
{
	var cloudTableMock = new Mock<CloudTable>(new Uri("http://unittests.localhost.com/FakeTable")
		, (TableClientConfiguration)null);  //apparently Moq doesn't support default parameters 
											//so have to pass null here
	
	//control what happens when ExecuteAsync is called
	cloudTableMock.Setup(table => table.ExecuteAsync(It.IsAny<TableOperation>()))
		.ReturnsAsync(new TableResult());
	var cloudTableClientMock = new Mock<CloudTableClient>(new Uri("http://localhost")
		, new StorageCredentials(accountName: "blah", keyValue: "blah")
		, (TableClientConfiguration)null);  //apparently Moq doesn't support default parameters 
											//so have to pass null here
	
	//control what happens when GetTableReference is called
	cloudTableClientMock.Setup(client => client.GetTableReference(It.IsAny<string>()))
		.Returns(cloudTableMock.Object);
	var logger = Mock.Of<ILogger<MyService>>();
	myService = new MyService(cloudTableClientMock.Object, logger);
}
c#
[TestMethod]
public async Task HelloWorldShouldReturnANullResult()
{
	//arrange
	var blah = "hello world";
	//act
	var result = await myService.GetMappingAsync(blah);
	//assert
	Assert.IsNull(result);
}
