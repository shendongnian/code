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
>in Forms,add a new interface
public interface ISettingsService
{
  void OpenSettings();
}
