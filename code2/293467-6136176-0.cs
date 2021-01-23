        private void BW_FriendInRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (this.isLoggedIn)
                    listIncomingRequests();
                Thread.Sleep(Config.mMessagesCheckSleep);
            }
        }
        private delegate void listIncomingRequestsDelegate();
        private void listIncomingRequests()
        {
            if (InvokeRequired)
            {
                listIncomingRequestsDelegate d = new listIncomingRequestsDelegate(listIncomingRequests);
                this.Invoke(d, new object[] { });
                return;
            }
           ...
        }
