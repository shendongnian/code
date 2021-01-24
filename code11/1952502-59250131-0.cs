using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Android.Views;
using App16.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(NoShiftEffect), "NoShiftEffect")]
namespace App16.Droid
{
    public class NoShiftEffect : PlatformEffect
    {
        protected override void OnAttached ()
        {
            if (!(Container.GetChildAt(0) is ViewGroup layout))
                return;
            if (!(layout.GetChildAt(1) is BottomNavigationView bottomNavigationView))
                return;
            // This is what we set to adjust if the shifting happens
            bottomNavigationView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
        }
        protected override void OnDetached ()
        {
        }
    }
}
Now add another `NoShiftEffect.cs` to your shared project:
using Xamarin.Forms;
namespace App16
{
    public class NoShiftEffect : RoutingEffect
    {
        public NoShiftEffect() : base("MyCompany.NoShiftEffect")
        {
        }
    }
}
And finally consume the effect in your `TabbedPage`:
<TabbedPage.Effects>
    <local:NoShiftEffect />
</TabbedPage.Effects>
Credits to James Montemagno and his post on it [here][3].
  [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/effects/introduction
  [2]: https://montemagno.com/remove-shifting-bottomnavigationview-android/
  [3]: https://montemagno.com/xamarin-forms-fully-customize-bottom-tabs-on-android-turn-off-shifting/
