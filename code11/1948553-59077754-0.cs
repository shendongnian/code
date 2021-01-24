    if (!CoreApplication.MainView.Dispatcher.HasThreadAccess)
                            await CoreApplication.MainView.Dispatcher.Yield();
                        await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                        {
    //update UI here
    })
