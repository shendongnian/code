public interface IStatusBar
{
    void HideStatusBar();
    void ShowStatusBar();
}
### in Android
We can use the plugin [CurrentActivityPlugin][1] .
Simply call the Init method on OnCreate of MainActivity
base.OnCreate(savedInstanceState);
CrossCurrentActivity.Current.Init(this, savedInstanceState);
Xamarin.Essentials.Platform.Init(this, savedInstanceState);
using Plugin.CurrentActivity;
using Android.Views;
using App16.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace App16.Droid
{
    public class StatusBarImplementation : IStatusBar
    {
        public StatusBarImplementation()
        {
        }
        WindowManagerFlags _originalFlags;
        #region IStatusBar implementation
        public void HideStatusBar()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }
        public void ShowStatusBar()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }
        #endregion
    }
}
###in iOS
[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace xxx.iOS
{
    public class StatusBarImplementation : IStatusBar
    {
        public StatusBarImplementation()
        {
        }
      
        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }
        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }
     
    }
}
###And in your MainPage
protected override void OnAppearing()
{
   base.OnAppearing();
   NavigationPage.SetHasNavigationBar(this, false);
   // hide
   DependencyService.Get<IStatusBar>().HideStatusBar();
}
protected override void OnDisappearing()
{
   base.OnDisappearing();
   NavigationPage.SetHasNavigationBar(this, true);
   // show
   DependencyService.Get<IStatusBar>().ShowStatusBar();
}
  [1]: https://github.com/jamesmontemagno/CurrentActivityPlugin
