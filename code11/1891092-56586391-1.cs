     private const int RequestCode = 1000;
        private void CheckForOverlayPermission()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.M) return;
            if (!Settings.CanDrawOverlays(this)) return;
            var intent = new Intent(Settings.ActionManageOverlayPermission);
            intent.SetPackage(PackageName);
            StartActivityForResult(intent, RequestCode);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RequestCode)
            {
                if (Settings.CanDrawOverlays(this))
                {
                    // we have permission
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }
