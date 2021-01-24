    using Android.Net;
    public SomeClass{
        public static Context _context = Android.App.Application.Context;
    
        ....
    
        /// <summary>
        /// Forces the wifi over cellular.
        /// </summary>
        public static void ForceWifiOverCellular()
        {
            ConnectivityManager connection_manager = (ConnectivityManager)_context.GetSystemService(Context.ConnectivityService);
    
            NetworkRequest.Builder request = new NetworkRequest.Builder();
            request.AddTransportType(TransportType.Wifi);
    
            var callback = new ConnectivityManager.NetworkCallback();
            connection_manager.RegisterNetworkCallback(request.Build(), new CustomNetworkAvailableCallBack());
    
        }
    
        /// <summary>
        /// Forces the cellular over wifi.
        /// </summary>
        public static void ForceCellularOverWifi()
        {
            ConnectivityManager connection_manager = (ConnectivityManager)_context.GetSystemService(Context.ConnectivityService);
    
            NetworkRequest.Builder request = new NetworkRequest.Builder();
            request.AddTransportType(TransportType.Cellular);
    
            connection_manager.RegisterNetworkCallback(request.Build(), new CustomNetworkAvailableCallBack());
        }
    }
    
    
    /// <summary>
    /// Custom network available call back.
    /// </summary>
    public class CustomNetworkAvailableCallBack : ConnectivityManager.NetworkCallback
    {
        public static Context _context = Android.App.Application.Context;
    
        ConnectivityManager connection_manager = (ConnectivityManager)_context.GetSystemService(Context.ConnectivityService);
    
        public override void OnAvailable(Network network)
        {
            //ConnectivityManager.SetProcessDefaultNetwork(network);    //deprecated (but works even in Android P)
            connection_manager.BindProcessToNetwork(network);           //this works in Android P
        }
    }
