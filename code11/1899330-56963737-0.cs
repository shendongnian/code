public interface ISettingsService
{
  void OpenSettings();
}
>in iOS 
using xxx.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
[assembly: Dependency(typeof(OpenSettingsImplement))]
namespace xxx.iOS
{
    public class OpenSettingsImplement : ISettingsService
    {
        public void OpenSettings()
        {
            var url = new NSUrl($"App-Prefs:");
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}
**Note:**
`App-Prefs:` is private api in iOS. So if you want to upload it to app store , it will may been rejected by the store .
>in Android
using Android.Content;
using xxx;
using xxx.Droid;
using Xamarin.Forms;
[assembly: Dependency(typeof(OpenSettingsImplement))]
namespace xxx.Droid
{
    public class OpenSettingsImplement : ISettingsService
    {
        public void OpenSettings()
        {
            Intent intentOpenSettings = new Intent();
            intentOpenSettings.SetAction(Android.Provider.Settings.ActionAirplaneModeSettings);
            Android.App.Application.Context.StartActivity(intentOpenSettings);
        }
    }
}
