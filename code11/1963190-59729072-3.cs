    private  void BtnPlayLocal_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                CrossMediaManager.Current.PlayFromResource("minions.mp4");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                CrossMediaManager.Current.Play("file:///android_asset/minions.mp4");
            }
          
        }
