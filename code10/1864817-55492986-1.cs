[assembly: Dependency(typeof(MyCustomClass))]    // Check this assembly
namespace ISSO_I.Droid.PlatformSpecific
{
    public class MyCustomClass: IMyInterface
    {
     /// your code here
    }
}
**EDIT 3:**
Call location Updates:
protected override void OnAppearing()
        {
            base.OnAppearing();
            ToIssoView = false;
            RequestLocationUpdates(); // Call this method
        }
Method to request location updates:
public async void RequestLocationUpdates()
        {
            /// check permission for location updates
            var hasPermission = await CommonStaffUtils.CheckPermissions(Permission.Location);
            if (!hasPermission)
                return;
            if (CrossGeolocator.Current.IsListening) return;
            MyMap.MyLocationEnabled = true;
            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            CrossGeolocator.Current.PositionError += Current_PositionError;
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
        }
public static async Task<bool> CheckPermissions(Permission permission)
		{
			var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
			var request = false;
			if (permissionStatus == PermissionStatus.Denied)
			{
				if (Device.RuntimePlatform == Device.iOS)
				{
					var title = $"{permission} Permission";
					var question = $"To use this plugin the {permission} permission is required. Please go into Settings and turn on {permission} for the app.";
					const string positive = "Settings";
					const string negative = "Maybe Later";
					var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
					if (task == null)
						return false;
					var result = await task;
					if (result)
					{
						CrossPermissions.Current.OpenAppSettings();
					}
					return false;
				}
				request = true;
			}
			if (!request && permissionStatus == PermissionStatus.Granted) return true;
			{
				var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(permission);
				if (!newStatus.ContainsKey(permission) || newStatus[permission] == PermissionStatus.Granted) return true;
				var title = $"{permission} Permission";
				var question = $"To use the plugin the {permission} permission is required.";
				const string positive = "Settings";
				const string negative = "Maybe Later";
				var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
				if (task == null)
					return false;
				var result = await task;
				if (result)
				{
					CrossPermissions.Current.OpenAppSettings();
				}
				return false;
			}
		}
  [1]: https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/app-fundamentals/dependency-service/
