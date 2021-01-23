    private void DeviceControl_LocationChanged(object sender, EventArgs e)
    {
        if (mConnectionPoint != null)
        {
            DeviceControl control = (DeviceControl)sender;
            mConnectionPoint.X = control.Location.X + control.Width / 2;
            mConnectionPoint.Y = control.Location.Y + control.Height / 2;
        }
    }
