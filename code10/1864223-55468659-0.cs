 public static async Task<List<Contact>> GetCodeValuesAsync(IContactRepository repo, int inst, CancellationToken ct)
If you do this it might be a better idea to move the lifecycle management of the repository one level up. In other words move the `using` statement to the caller:
using(var repo = new ContactRepository())
{
    await ContactsCache.GetContactsAsync(repo , It.IsAny<int>(), CancellationToken.None);
}
Then in your test you would be able to do this:
var mock = new Mock<IContactsRepository>()
        .Setup(x => x.LoadAsync(It.IsAny<int>(), CancellationToken.None))
        .ReturnsAsync(new List<Contact>(expected));
var actual = await ContactsCache.GetContactsAsync(mock , It.IsAny<int>(), CancellationToken.None);
**Preferrable solutions:**
I'm assuming that your repository is responsible for session management (hence the IDisposable interface). If there is a way for you to separate your repository interface from whatever resources some of the implementations may need to release, you can move to a constructor injection approach.
Your code will then look something like the following:
public class ContactsCache : IContactsCache
{
    private readonly IContactRepository contactRepo;
    public ContactsCache(IContactRepository contactRepo)
    {
        this.contactRepo = contactRepo;
    }
    // ...
    return await this.contactRepo.LoadAsync(inst, ct).ConfigureAwait(false);
    // ...
}
And your unit test will look like this:
[TestMethod]
public async void GetContactAsync_WhenCalled_ReturnCodeValuesCache()
{
    var expected = new List<Contact>
    {
        new Contact() {Instance = 1, Name = "Test" }
    };
    var mock = new Mock<IContactsRepository>()
        .Setup(x => x.LoadAsync(It.IsAny<int>(), CancellationToken.None))
        .ReturnsAsync(new List<Contact>(expected));
    var cache = new ContactsCache(mock);
    var actual = await cache .GetContactsAsync(It.IsAny<int>(), CancellationToken.None);
    CollectionAssert.AreEqual(actual, expected);
}
You may also consider reversing the dependency between cache and repository. In other words your repository implementation can have a cache. This allows you to choose your caching strategy more dynamically. For example you could have either of the following:
var repo = new ContactRepository(new MemoryCache<Contact>())
or
`var repo = new ContactsRepository(new NullCache<Contact>())` <-- if you don't need caching in some contexts.
This approach means that the consumer of your repository does not need to know or care about where the data comes from. This allows you to test your caching mechanism without needing a repository in the first place. Of course if you want to test the repository, you will need to provide it with a caching strategy.
Following this approach also gives you access to a fairly quick solution, since you can wrap your existing static cache with a class like this:
public class MemoryCache : ICachingStrategy<Contact>
{
    public async Task<List<Contact>> GetCodeValuesAsync(int inst, CancellationToken ct) // This comes from the interface
    {
        return await ContactsCache.GetContactsAsync(inst, ct); // Just forward the call to the existing static cache
    }
}
Your repository will need some work to make it consider the cache before hitting the db/file system/remote resource.
Side note - if you `new` up 'dependencies' you are no longer doing dependency injection.
