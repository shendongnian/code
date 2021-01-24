C#
public static void CreateFireAndForgetWork<T>(this Task<T> Job, Action<Exception> OnError = null) where T : struct
{
  Action work = async () =>
  {
    try
    {
      await Job;
    }
    catch (Exception ex)
    {
      ...
    }
  };
  work();
}
