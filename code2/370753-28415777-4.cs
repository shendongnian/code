    using System;
	using System.Runtime.InteropServices.ComTypes;
	using System.Diagnostics;
	using NETWORKLIST;
	namespace SharpDisplayManager
	{
		public class NetworkManager: INetworkListManagerEvents, IDisposable
		{
			public delegate void OnConnectivityChangedDelegate(NetworkManager aNetworkManager, NLM_CONNECTIVITY aConnectivity);
			public event OnConnectivityChangedDelegate OnConnectivityChanged;
			
			private int iCookie = 0;
			private IConnectionPoint iConnectionPoint;
			private INetworkListManager iNetworkListManager;
			public NetworkManager()
			{
				iNetworkListManager = new NetworkListManager();
				ConnectToNetworkListManagerEvents();
			}
			public void Dispose()
			{
				//Not sure why this is not working form here
				//Possibly because something is doing automatically before we get there
				//DisconnectFromNetworkListManagerEvents();
			}
			public INetworkListManager NetworkListManager
			{
				get { return iNetworkListManager; }
			}
			public void ConnectivityChanged(NLM_CONNECTIVITY newConnectivity)
			{
				//Fire our event
				OnConnectivityChanged(this, newConnectivity);
			}
			public void ConnectToNetworkListManagerEvents()
			{
				Debug.WriteLine("Subscribing to INetworkListManagerEvents");
				IConnectionPointContainer icpc = (IConnectionPointContainer)iNetworkListManager;
				//similar event subscription can be used for INetworkEvents and INetworkConnectionEvents
				Guid tempGuid = typeof(INetworkListManagerEvents).GUID;
				icpc.FindConnectionPoint(ref tempGuid, out iConnectionPoint);
				iConnectionPoint.Advise(this, out iCookie);
				
			}
			public void DisconnectFromNetworkListManagerEvents()
			{
				Debug.WriteLine("Un-subscribing to INetworkListManagerEvents");
				iConnectionPoint.Unadvise(iCookie);
			} 
		}
	}
