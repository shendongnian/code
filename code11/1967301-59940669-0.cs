    303         public async Task DataReceived_CLIENT_EVENT()
    304         {
    305             try
    306             {
    307                 /* We can't occupy the precondition, if BT feature is not supported in Manual TC */
    308                 if (_isBluetoothSupported == false)
    309                 {
    310                     BluetoothHelper.DisplayLabel("DataReceived_CLIENT_EVENT");
    311                     await ManualTest.WaitForConfirm();
    312                     return;
    313                 }
    314 
    315                 BluetoothSetup.CreateClientSocketUtil();
    316                 if (BluetoothSetup.Client == null)
    317                 {
    318                     ManualTest.DisplayCustomLabel("Precondition failed: Test device should be paired to the remote device.");
    319                     await ManualTest.WaitForConfirm();
    320                     return;
    321                 }
    322 
    323                 await BluetoothSetup.ConnectSocketUtil();
    324                 BluetoothSetup.Client.DataReceived += (sender, args) =>
    325                 {
    326                     Log.Info(Globals.LogTag, "DataReceived in client: "+args.Data.Data);
    327                     BluetoothHelper.DisplayPassLabel("DataReceived_SERVER_EVENT");
    328                 };
    329                 await ManualTest.WaitForConfirm();
