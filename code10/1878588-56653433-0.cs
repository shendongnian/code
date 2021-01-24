    miraDeviceWatcher = DeviceInformation.CreateWatcher(CastingDevice.GetDeviceSelector(CastingPlaybackTypes.Video)); 
    miraHandlerAdded = new TypedEventHandler<DeviceWatcher, DeviceInformation>(async (watcher, deviceInfo) =>
    {
       await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
       {
          //Add each discovered device to our listbox
          CastingDevice addedDevice = await CastingDevice.FromIdAsync(deviceInfo.Id);
          var disp = new CastingDisplay(addedDevice); //my viewmodel
          MiraDevices.Add(disp); //ObservableCollection
       });
    });
    miraDeviceWatcher.Added += miraHandlerAdded;
