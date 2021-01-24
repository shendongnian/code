public IMvxCommand OnFilterLabel
    {
        get
        {
            return new MvxCommand(async() =>
            {
                await PopupNavigation.Instance.PushAsync(new FilterAttendPopup());
                MessagingCenter.Subscribe<Attendance>(this, "ReceiveData", (value)=> { });
            });
        }
    }
If you want to use "Navigation", you have to add this using : 
using Rg.Plugins.Popup.Extensions;
