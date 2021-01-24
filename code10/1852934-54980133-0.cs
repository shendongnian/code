    handlerAdded = new TypedEventHandler<DeviceWatcher, DeviceInformation>(async (watcher, deviceInfo) =>
    {
        // Since we have the collection databound to a UI element, we need to update the collection on the UI thread.
        await rootPage.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
        {
            ResultCollection.Add(new DeviceInformationDisplay(deviceInfo));
    
            rootPage.NotifyUser(
                String.Format("{0} devices found.", ResultCollection.Count),
                NotifyType.StatusMessage);
        });
    });
