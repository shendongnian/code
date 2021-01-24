    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Acr.UserDialogs;
    using Android;
    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.OS;
    using Android.Runtime;
    using Android.Support.V4.App;
    using Android.Views;
    using Android.Widget;
    using Java.Lang;
    using Java.Util.Concurrent;
    using Microsoft.AspNet.SignalR.Client;
    using Microsoft.AspNet.SignalR.Client.Transports;
    using Android.Net;
    using Android.Media;
    
    namespace My_Android_service
    {
        [Service]
        public class SignalRSrv : Service
        {
            private bool InstanceFieldsInitialized = false;
            private string username = "";
            private string firstname = "";
            private string lastname = "";
            private string companny = "";
            private string department = "";
            private string section = "";
            private int notifyid = 0;
    
            private void InitializeInstanceFields()
            {
                mBinder = new LocalBinder(this);
            }
    
            private Handler mHandler; // to display any received messages
            private IBinder mBinder; // Binder given to clients
            private SignalRSingleton mInstance;
            private Notification notification = null;
    
            public SignalRSrv()
            {
                if (!InstanceFieldsInitialized)
                {
                    InitializeInstanceFields();
                    InstanceFieldsInitialized = true;
                }
    
            }
    
            public override void OnCreate()
            {
                base.OnCreate();
                mInstance = SignalRSingleton.getInstance();
                mHandler = new Handler(Looper.MainLooper);
            }
    
            public override void OnDestroy()
            {
               try
                {
                    base.OnDestroy();
    
                }
                catch (System.Exception e)
                {
                    var m = e.Message;
                }
            }
    
    
            public override IBinder OnBind(Intent intent)
            {
    
                User MyUser = new User("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                Bundle bundlee = intent.GetBundleExtra("TheBundle");
                MyUser = bundlee.GetParcelable("MyUser") as User;
    
                username = MyUser.Username;
                firstname = MyUser.Firstname;
                lastname = MyUser.Lastname;
                company = intent.GetStringExtra("theSelectedCompany");
                department = intent.GetStringExtra("theSelectedDepartment");
                Section = intent.GetStringExtra("theSelectedSection");
    
                startSignalR(bundlee);
                return mBinder;
            }
    
            private void startSignalR(Bundle bundle)
            {
                mInstance.setmHubConnection(username, firstname,lastname,company,department,section);
                mInstance.setHubProxy();
    
                try
                {
                    // Connect the client to the hub
                    mInstance.mHubConnection.Start();
    
                    // Setup the event handler for message received
                    mInstance.mHubProxy.On("broadcastMessage", (string platform, string message) =>
                    {
                        try
                        {
                            showNotification(message, bundle, notification);
    
                        }
                        catch (System.Exception e)
                        {
                           var error = e.Message;
                        }
                    });
    
                }
                catch (System.Exception e) when (e is InterruptedException || e is ExecutionException)
                {
                    // handle any errors
                    var x = 1;
                    return;
                }
            }
    
            public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
            {
    
                User MyUser = new User("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                Bundle bundlee = intent.GetBundleExtra("TheBundle");
                MyUser = bundlee.GetParcelable("MyUser") as User;
    
                username = MyUser.Username;
                firstname = MyUser.Firstname;
                lastname = MyUser.Lastname;
                company = intent.GetStringExtra("theSelectedCompany");
                department = intent.GetStringExtra("theSelectedDepartment");
                section = intent.GetStringExtra("theSelectedSection");
    
                startSignalR(bundlee);
    
                // Set up Notification
                Notification notify = new Notification();
                notify.Defaults = NotificationDefaults.Sound;
                notify.Defaults = NotificationDefaults.Vibrate;
    
                // Start Notification system, app will crash without this
                StartForeground(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notify);
    
                return StartCommandResult.Sticky;
            }
    
            public void showNotification(string message, Bundle bundle, Notification notification)
            {
                try
                {
                    // Activity to open when notification clicked, I'm not doing this yet.
                    //Intent intent = new Intent(this, typeof(Drawer)); //Activity you want to open
                    //intent.AddFlags(ActivityFlags.ClearTop);
                    //intent.PutExtra("TheBundle", bundle);
                    //var pendingIntent = PendingIntent.GetActivity(this, RandomGenerator(), intent, PendingIntentFlags.OneShot);
    
                    NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this)
                         .SetSmallIcon(Resource.Drawable.alert_box)
                         .SetContentTitle("Message Received")
                         .SetContentText(message)
                         //.SetSound(Settings.System.DefaultNotificationUri)
                         .SetVibrate(new long[] { 1000, 1000 })
                         .SetLights(Color.AliceBlue, 3000, 3000)
                         .SetAutoCancel(true);
                    //.SetContentIntent(pendingIntent);
    
    
                    // If this is oreo or above, we need a channel
                    NotificationChannel channel = null;
    
                    // Set sound to be used for notification
                    Android.Net.Uri alarmSound = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
    
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                    {
                        string channelId = "OML_Messenger"; //Context.GetString(Resource.String.default_notification_channel_id);
                        channel = new NotificationChannel(channelId, "Message Received", NotificationImportance.Default);
                        channel.Description = ("Message Received From Administrator");
                        notificationBuilder.SetSound(alarmSound);
                        notificationBuilder.SetChannelId(channelId);
                    }
                    
                    // Connect to the notification system setup in OnStartCommandResult
                    NotificationManager notificationManager = (NotificationManager)Android.App.Application.Context.GetSystemService(Context.NotificationService);
    
                    // Create the channel, if not null
                    if (!channel == null)
                    {
                        notificationManager.CreateNotificationChannel(channel);
                    }
                    notifyid = RandomGenerator(); // Get a channel ID
    
                    // Send the noitification
                    notificationManager.Notify(notifyid, notificationBuilder.Build());
    
                }
                catch (System.Exception e)
                {
                    var error = e.Message;
                }
            }
            private int RandomGenerator()
            {
                return new Random().Next(int.MinValue, int.MaxValue);
            }
        }
    
        public class LocalBinder : Binder
        {
            private readonly SignalRSrv outerInstance;
    
            public LocalBinder(SignalRSrv outerInstance)
            {
                this.outerInstance = outerInstance;
            }
    
            public virtual SignalRSrv Service
            {
                get
                {
                    // Return this instance of SignalRSrv so clients can call public methods
                    return outerInstance;
                }
            }
        }
    }
