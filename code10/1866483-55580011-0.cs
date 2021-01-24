C#
public override Task<ValidationResult> Validate(object objectToValidate)
{
  try
  {
    // Perform only synchronous calls here. No use of the await keyword.
    return Task.FromResult(new ValidationResult { /* ... */ });
  }
  catch (Exception ex)
  {
    return Task.FromException<ValidationResult>(ex);
  }
}
Alternatively, you can use `async` without `await` and suppress the warning with a `#pragma`:
C#
#pragma warning disable 1998
public override async Task<ValidationResult> Validate(object objectToValidate)
#pragma warning restore 1998
{
  // Perform only synchronous calls here. No use of the await keyword.
  return new ValidationResult { /* ... */ };
}
If you do this a lot, you can look into creating a helper method. [This one][1] is part of Nito.AsyncEx:
C#
public static class TaskHelper
{
#pragma warning disable 1998
  public static async Task ExecuteAsTask(Action func)
#pragma warning restore 1998
  {
    func();
  }
#pragma warning disable 1998
  public static async Task<T> ExecuteAsTask<T>(Func<T> func)
#pragma warning restore 1998
  {
    return func();
  }
}
So if you install Nito.AsyncEx or include the code above in your project, then you can use the `ExecuteAsTask` method as such:
C#
using static Nito.AsyncEx.TaskHelper;
...
public override Task<ValidationResult> Validate(object objectToValidate)
{
  return ExecuteAsTask(() => {
    // Perform only synchronous calls here. No use of the await keyword.
    return new ValidationResult { /* ... */ };
  });
}
  [1]: https://github.com/StephenCleary/AsyncEx/blob/11fa00e55c7a421e62ec0cdb18b58c2c68b9d5c1/src/Nito.AsyncEx.Tasks/TaskHelper.cs
