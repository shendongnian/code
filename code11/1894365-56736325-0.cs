C#
async Task RunEvery10s()
{
  while (true)
    await Every10s();
}
async Task RunEvery30s()
{
  while (true)
    await Every30s();
}
await Task.WhenAll(RunEvery10s(), RunEvery30s());
