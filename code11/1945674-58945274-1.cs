public class ListItemDTO { public string Name { get; set; } }
public interface IRepo
{
	Task<IEnumerable<T>> GetListAsync<T>(string storedProcedure, object template);
}
public class Ctrl
{
	private readonly IRepo repo;
	public Ctrl(IRepo repo) { this.repo = repo; }
	// BTW. Check out IAsyncEnumerable<T> 
	public async Task<IEnumerable<ListItemDTO>> GetAync()
		=> await repo.GetListAsync<ListItemDTO>("spGetAccountList", new { @ParamAccountID = 1 });
}
[TestClass]
public class UnitTest1
{
	[TestMethod]
	public async Task Test1()
	{
		var mockRepo = new Mock<IRepo>(MockBehavior.Strict);
		IEnumerable<ListItemDTO> expected = new List<ListItemDTO>() { new ListItemDTO { Name = "Prince" } };
		mockRepo.Setup(repo => repo.GetListAsync<ListItemDTO>(It.IsAny<string>(), It.IsAny<object>()))
				.ReturnsAsync(expected);
		var tested = new Ctrl(repo: mockRepo.Object);
		var actual = await tested.GetAync();
		Assert.IsNotNull(actual);
		Assert.AreEqual(1, actual.Count(), "Expecting exactly one item");
		var first = actual.First();
		Assert.AreEqual("Prince", first.Name, "Checking 1st item's 'Name'");
	}
}
The library setup is as follows:
<package id="Moq" version="4.13.1" targetFramework="net472" />
<package id="MSTest.TestAdapter" version="2.0.0" targetFramework="net472" />
<package id="MSTest.TestFramework" version="2.0.0" targetFramework="net472" />
