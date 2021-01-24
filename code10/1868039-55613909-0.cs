C#
var progress1 = new Progress<string>(update =>
{
  foreach (var ctrl in list1)
    ctrl.Text = update;
});
var progress2 = new Progress<string>(update =>
{
  foreach (var ctrl in list2)
    ctrl.Text = update;
});
tasks.Add(Task.Run(() => ChangeText(progress1)));
tasks.Add(Task.Run(() => ChangeText(progress2)));
await Task.WhenAll(tasks);
...
private void ChangeText(IProgress<string> progress)
{
  progress?.Update("22");
}
One nice benefit of using the `IProgress<T>` approach is that your processing code is now testable without a UI. I.e., you can write unit tests for it.
  [1]: https://stackoverflow.com/a/55604527/263693
