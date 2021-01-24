csharp
using System;
using Android.App;
using Android.Runtime;
using Shiny;
namespace LocalNotificationsSample.Droid
{
    [Application]
    public class YourApplication : Application
    {
        public YourApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            AndroidShinyHost.Init(this, platformBuild: services => services.UseNotifications());
            Notifications.AndroidOptions.DefaultSmallIconResourceName = "icon.png";
        }
    }
}
In `MainActivity.cs`, in `OnRequestPermission`, add the allow Shiny to present request notifications permissions from the user by adding `Shiny.AndroidShinyHost.OnRequestPermissionsResult(requestCode, permissions, grantResults);`
csharp
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
namespace LocalNotificationsSample.Droid
{
    [Activity(Label = "LocalNotificationsSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Shiny.AndroidShinyHost.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}
### iOS 
In `AppDelegate.cs`, in `FinishedLaunching`, initialize Shiny by calling `Shiny.iOSShinyHost.Init`:
csharp
using Foundation;
using UIKit;
using Shiny;
namespace LocalNotificationsSample.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            iOSShinyHost.Init(platformBuild: services => services.UseNotifications());
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
## 3. Schedule a Local Notification
In this example, we will schedule a Local Notification to be sent 5 Seconds after the app launches
csharp
using System;
using System.Threading.Tasks;
using Shiny;
using Shiny.Notifications;
using Xamarin.Forms;
namespace LocalNotificationsSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
        protected override async void OnStart()
        {
            await ScheduleLocalNotification(DateTimeOffset.UtcNow.AddSeconds(5));
        }
        Task ScheduleLocalNotification(DateTimeOffset scheduledTime)
        {
            var notification = new Notification
            {
                Title = "Testing Local Notifications",
                Message = "It's working",
                ScheduleDate = scheduledTime
            };
            return ShinyHost.Resolve<INotificationManager>().Send(notification);
        }
    }
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/HMkgo.jpg
