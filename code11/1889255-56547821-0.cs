        private void startSignalR()
        {
            // Company, Department, and section are private variables
            // their values are pulled from the intent bundle 
            // in the OnBind method, that code is:
            //     Bundle bundlee = intent.GetBundleExtra("TheBundle");
            //     MyUser = bundlee.GetParcelable("MyUser") as User;
            // This information is put into the bundle when the user is logged in.
            // I then pass that information to the SignalR client 
            // when I set the hub connection and placed on the querystring to the hub.
            mInstance.setmHubConnection(username, firstname,lastname,company,department,section);
            mInstance.setHubProxy();
            try
            {
                // Connect the client to the hup
                mInstance.mHubConnection.Start();
                // Set the event handler
                mInstance.WireUp();
            }
            catch (System.Exception e) when (e is InterruptedException || e is ExecutionException)
            {
                ShowMessage("Error: + e.Message)
            }
        }
