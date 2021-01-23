    Messenger.Default.Register<BroadcastPropertyChanged<ControlContainerTemplate>>(this, (message) =>
            {
                //// Instance needs to find out if it is a real receiver
                if (_udfViewModel != null && _udfViewModel.ControlsValue.Any((c) => message.Sender == c))
                    RaiseBooleanFlagsChanged();
            });
            Messenger.Default.Register<BroadcastPropertyChanged<ChargeTemplateViewModel>>(this, (message) =>
                {
                    //// Instance needs to find out if it is a real receiver
                    if (_chargeTemplates != null && _chargeTemplates.Any((c) => message.Sender == c))
                        RaiseBooleanFlagsChanged();
    });
