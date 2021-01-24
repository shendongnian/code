    rootPage.Accel_x.ValueChanged += async delegate (GattCharacteristic sender, GattValueChangedEventArgs args)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                        var reader = DataReader.FromBuffer(args.CharacteristicValue);
                        SData.Acceleration_x = reader.ReadByte();
                    });
                };
