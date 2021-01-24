    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (DataServices.Instance.State == DataServicesState.Up && _timeSeries.ServiceInformation.State == ServiceState.Up)
        {
        }
        else
        {
            Application.Current.Dispatcher.Invoke(
                () =>
                {
                    OpenConnections();
                });
        }
    }
