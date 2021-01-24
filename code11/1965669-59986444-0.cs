    using System;
    using System;
    using System.Threading;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using OomaAndroid.Models;
    using SQLite;
    namespace OomaAndroid
    {
        [Service]
        public class ServiceTest : Service
        {
            Timer timer;        
            public override void OnCreate()
            {
                base.OnCreate();
            }
            public override IBinder OnBind(Intent intent)
            {            
                return null;
            }
            public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
            {            
                timer = new Timer(HandleTimerCallback, 0, 0, 900000);
                return base.OnStartCommand(intent, flags, startId);
            }
            private void HandleTimerCallback(object state)
            {
                //this part codes will run every 15 minutes
            }
        }    
    }
