          private void BtncheckAndTurnOnDeviceManager_Click(object sender, System.EventArgs e)
             {
            Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
            intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, adminReceiver);
            intent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "After you turn it on, you can use the lock screen function....");
            StartActivityForResult(intent, 0);
          
        }
        private void Btncheckscreenoff_Click(object sender, System.EventArgs e)
        {
            bool admin = policyManager.IsAdminActive(adminReceiver);
            if (admin)
            {
                policyManager.LockNow();
            }
            else
            {
                showToast("No device management permissions");
            }
          
        }
        private void Btncheckscreenon_Click(object sender, System.EventArgs e)
        {
            mWakeLock = mPowerManager.NewWakeLock(WakeLockFlags.Partial, "tag");
            mWakeLock.Acquire();
            mWakeLock.Release();
          
        }
        private void Btncheckscreen_Click(object sender, System.EventArgs e)
        {
            PowerManager pm = (PowerManager)GetSystemService(Context.PowerService);
            bool screenOn = pm.IsScreenOn;
            if (!screenOn)
            {
                showToast("The screen is a black screen");
            }
            else
            {
                showToast("The screen is bright");
            }
          
        }
