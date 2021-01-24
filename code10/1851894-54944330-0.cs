    private void SearchDevicesEvent(object sender,
                                            ClassListOfDevices.EventSearchDevicesArg e)
            {
                BeginInvoke(new ClassListOfDevices.SearchDevicesEventHandler(UpdataSearchDevicesEvent),
                            new[] { sender, e });
            }
