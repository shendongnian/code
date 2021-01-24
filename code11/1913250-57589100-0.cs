           IntentFilter filter1;
        IntentFilter filter2;
        IntentFilter filter3;     
     protected override async void OnCreate(Bundle savedInstanceState)
        {    
            filter1 = new IntentFilter(BluetoothDevice.ActionAclConnected);
            filter2 = new IntentFilter(BluetoothDevice.ActionAclDisconnectRequested);
            filter3 = new IntentFilter(BluetoothDevice.ActionAclDisconnected);
            LoadApplication(new App());
        }
        protected override void OnResume()
        {
            this.RegisterReceiver(broadCastMonitor, filter1);
            this.RegisterReceiver(broadCastMonitor, filter2);
            this.RegisterReceiver(broadCastMonitor, filter3);
            base.OnResume();
        }
        protected override void OnPause()
        {
            this.UnregisterReceiver(broadCastMonitor);
            base.OnPause();
        }  
           public override void OnReceive(Context context, Intent intent)
        {
            String action = intent.Action;
            if (BluetoothDevice.ActionAclConnected.Equals(action))
            {
                //Do something if connected
                Toast.MakeText(context, "Bluetooth Connected" + GlobalCache.ConnectedDeviceInfo.Name, ToastLength.Short).Show();
            }
            else if (BluetoothDevice.ActionAclDisconnected.Equals(action))
            {
                Toast.MakeText(context, "Bluetooth disconnected", ToastLength.Short).Show();
            }
            else if (BluetoothDevice.ActionAclDisconnectRequested.Equals(action))
            {
                Toast.MakeText(context, "Bluetooth disconnecting..", ToastLength.Short).Show();
            }
        }
