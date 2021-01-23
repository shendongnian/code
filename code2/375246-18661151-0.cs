    public sealed partial class NamePage
    {
      private readonly Task _initializingTask;
      public NamePage()
      {
        _initializingTask = Init();
      }
      private async Task Init()
      {
        /*
        Initialization that you need with await/async stuff allowed
        */
      }
    }
