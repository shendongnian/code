C#
Task Task0();
Task Task1();
Task Task2();
Task Task3();
> Task 1 is after task 0. Task 3 is after task 2.
You can link/chain tasks using `await`:
C#
async Task Task0and1()
{
  await Task0();
  await Task1();
}
async Task Task2and3()
{
  await Task2();
  await Task3();
}
> Task 0 and Task 2 can be parallel.
Use `Task.WhenAll` for asynchronous concurrency:
C#
var task0and1 = Task0and1();
var task2and3 = Task2and3();
await Task.WhenAll(task0and1, task2and3);
> Task 1 and task 3 is done only one by one, that is, task 1 after task 3 or task 3 after task 1.
Use `SemaphoreSlim` for an asynchronous-compatible lock:
C#
private SemaphoreSlim _mutex = new SemaphoreSlim(1);
async Task Task0and1()
{
  await Task0();
  await _mutex.WaitAsync();
  try { await Task1(); }
  finally { _mutex.Release(); }
}
async Task Task2and3()
{
  await Task2();
  await _mutex.WaitAsync();
  try { await Task3(); }
  finally { _mutex.Release(); }
}
Final code:
C#
private SemaphoreSlim _mutex = new SemaphoreSlim(1);
async Task Task0and1()
{
  await Task0();
  await _mutex.WaitAsync();
  try { await Task1(); }
  finally { _mutex.Release(); }
}
async Task Task2and3()
{
  await Task2();
  await _mutex.WaitAsync();
  try { await Task3(); }
  finally { _mutex.Release(); }
}
async Task WholeTask()
{
  var task0and1 = Task0and1();
  var task2and3 = Task2and3();
  await Task.WhenAll(task0and1, task2and3);
}
