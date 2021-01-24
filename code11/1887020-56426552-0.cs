`C#
public async Task myMethodAsync
{
...
await myRepository.AddAsync(entity);
DoSomeWork(id, (Repository)myRepository.Clone());
}
private async Task DoSomeWork(Guid id, Repository clonedRepository)
{
  ...
  var someEntity = await clonedRepository.GetAsync(id);
}
`
