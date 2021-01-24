        public class ScreenOffAdminReceiver: DeviceAdminReceiver
        {
        private void showToast(Context context,string msg)
        {
            Toast.MakeText(context, msg, ToastLength.Short).Show();
        }
        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);
            showToast(context, "Device Manager enable");
        }
        public override void OnDisabled(Context context, Intent intent)
        {
            base.OnDisabled(context, intent);
            showToast(context, "Device Manager is not enabled");
        }
    }
    
