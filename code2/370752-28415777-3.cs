		public void OnConnectivityChanged(NetworkManager aNetwork, NLM_CONNECTIVITY newConnectivity)
		{
			//Update network status
			UpdateNetworkStatus();			
		}
		/// <summary>
		/// Update our Network Status
		/// </summary>
		private void UpdateNetworkStatus()
		{
            //TODO: Test the following functions to get network and Internet status
            //iNetworkManager.NetworkListManager.IsConnectedToInternet
            //iNetworkManager.NetworkListManager.IsConnected
		}
