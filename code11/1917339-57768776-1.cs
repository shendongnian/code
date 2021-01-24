    using System.ComponentModel;
    if (Device.RuntimePlatform == Device.iOS)
    {        
        Console.WriteLine("version is -- " + CrossDeviceInfo.Current.Version);
        if (Convert.ToInt32(CrossDeviceInfo.Current.Version) >= 10)
        {
            MyImageButton.Source = "FaceId.png";
        }
        else
        {
            MyImageButton.Source = "fingerprint.png";
        }
    }
    else if (Device.RuntimePlatform == Device.Android)
    {
        MyImageButton.Source = "fingerprint.png";
    }
