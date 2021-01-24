    [assembly: Dependency(typeof(DeviceService))]
    class DeviceService : IDeviceService
        {
            public bool GetApplicationNotificationSettings()
            {
                var context = Android.App.Application.Context;
                if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
                {
                    return NotificationManagerCompat.From(context).AreNotificationsEnabled();
                }
                else
                {
                    AppOpsManager mAppOps = (AppOpsManager)context.GetSystemService(Android.Content.Context.AppOpsService);
                    ApplicationInfo applicationInfo = context.ApplicationInfo;
                    string packageName = context.ApplicationContext.PackageName;
                    int uId = applicationInfo.Uid;
    
                    var appOpsClass = Class.ForName("android.app.AppOpsManager");
                    var checkOpNoThrowMethod = appOpsClass.GetMethod("checkOpNoThrow", Java.Lang.Integer.Type, Java.Lang.Integer.Type, new Java.Lang.String().Class);
                    var opsPostNotificationValue = appOpsClass.GetDeclaredField("OP_POST_NOTIFICATION");
                    var value = (int)opsPostNotificationValue.GetInt(Java.Lang.Integer.Type);
                    var mode = (int)checkOpNoThrowMethod.Invoke(mAppOps, value, uId, packageName);
                    return (mode == (int)AppOpsManagerMode.Allowed);
                }
            }
        }
