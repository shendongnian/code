namespace *.Services.Interfaces
{
    public interface IForceKeyboardDismissalService
    {
        void DismissKeyboard();
    }
}
> Phone specific code
using Plugin.CurrentActivity;  //Nugget used to get activity
[assembly: Xamarin.Forms.Dependency(typeof(AndroidForceKeyboardDismissalService))]
namespace *.Droid.PhoneSpecific
{
    public class AndroidForceKeyboardDismissalService : IForceKeyboardDismissalService
    {
        public void DismissKeyboard()
        {
            var imm = InputMethodManager.FromContext(CrossCurrentActivity.Current.Activity.ApplicationContext);
            imm?.HideSoftInputFromWindow(CrossCurrentActivity.Current.Activity.Window.DecorView.WindowToken, HideSoftInputFlags.NotAlways);
            var currentFocus = CrossCurrentActivity.Current.Activity.CurrentFocus;
            if (currentFocus != null && currentFocus is EditText)
                currentFocus.ClearFocus();
        }
    }
}
> Usage 
DependencyService.Get<IForceKeyboardDismissalService>().DismissKeyboard();
Let me know if its working for you.
