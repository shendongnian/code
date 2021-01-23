    private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
    // Microsoft.AspNet.Identity.AsyncHelper
    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
    {
	    CultureInfo cultureUi = CultureInfo.CurrentUICulture;
    	CultureInfo culture = CultureInfo.CurrentCulture;
	    return AsyncHelper._myTaskFactory.StartNew<Task<TResult>>(delegate
	    {
		    Thread.CurrentThread.CurrentCulture = culture;
		    Thead.CurrentThread.CurrentUICulture = cultureUi;
		    return func();
    	}).Unwrap<TResult>().GetAwaiter().GetResult();
    }
