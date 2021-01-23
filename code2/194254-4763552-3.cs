        protected void DisplayName_Get(PremiseServer server)
        {
            String propertyName = _DisplayName.PropertyName;
            _DisplayName.UpdatedFromServer = false;
            server.GetPropertyAsync(Location, propertyName, (HttpResponseArgs) =>
            {
                if (HttpResponseArgs.Succeeded)
                {
                    //Debug.WriteLine("Received {0}: {1} = {2}", DisplayName, propertyName, HttpResponseArgs.Response);
                    DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    {
                        DisplayName = (String)HttpResponseArgs.Response; // <-- this is the whole cause of this confusing architecture
                        _DisplayName.UpdatedFromServer = true;
                        HasRealData = true;
                    });
                }
            });
        }
