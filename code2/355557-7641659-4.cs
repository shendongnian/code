    MapButtonClicked(...)
    {
        if (!Settings.HasSetting("allowLocation") || 
            !((bool)Settings.GetSetting("allowLocation"))
        {
            MessageBox.Show("Allow app to use your location?, "Location Services",MessageBoxButtons.OkCancel);
        }
        //handle result
        else
        {
            StartLocationSearch();
        }
    }
