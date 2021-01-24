                handlerUpdated = new TypedEventHandler<DeviceWatcher, DeviceInformationUpdate>(async (watcher, deviceInfoUpdate) =>
                {
                    // Since we have the collection databound to a UI element, we need to update the collection on the UI thread.
                    await MainPage.Current.UIThreadDispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
                    {
                        // Find the corresponding updated DeviceInformation in the collection and pass the update object
                        // to the Update method of the existing DeviceInformation. This automatically updates the object
                        // for us.
                        foreach (BluetoothDeviceInformationDisplay deviceInfoDisp in bluetoothDeviceObservableCollection)
                        {
                            if (deviceInfoDisp.Id == deviceInfoUpdate.Id)
                            {
                                if (deviceInfoDisp.DeviceInformation.Pairing.CanPair)
                                {
                                    await deviceInfoDisp.DeviceInformation.Pairing.Custom.PairAsync(DevicePairingKinds.ConfirmOnly);
                                }
    
                                deviceInfoDisp.Update(deviceInfoUpdate);
                                break;
                            }
                        }
                    });
                });
                deviceWatcher.Updated += handlerUpdated;
