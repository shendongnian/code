c#
[Fact]
[DotMemoryUnit(FailIfRunWithoutSupport = false)]
public void DummyContext_DisposesContextOnGarbageCollect()
{
    var isolator = new Action(
        () =>
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DummyContext>()
                .UseSqlServer("data source=ASqlServer;Integrated Security=true");
            using (var ctx = new DummyContext(options.Options))
            {
                // do nothing
            }
        });
    isolator();
    GC.Collect();
    GC.WaitForPendingFinalizers();
    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
    dotMemory.Check(
        memory =>
            Assert.Equal(
                0,
                memory.GetObjects(where => where.Type.Is<DummyContext>()).ObjectsCount));
}
  [1]: https://blog.jetbrains.com/dotnet/2018/10/04/unit-testing-memory-leaks-using-dotmemory-unit/
