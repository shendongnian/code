    public void deviceIcon_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Image image = e.Source as Image;
        if (image != null)
        {
            string ipAddress = (string)image.Tag;
            Device device = devices.FirstOrDefault(d => d.IpAddress == ipAddress);
            if (device != null)
            {
                ConnexDeviceWindow deviceWindow = new ConnexDeviceWindow(device);
                deviceWindow.Show();
            }         
        }
    }
