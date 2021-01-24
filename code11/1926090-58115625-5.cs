    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        var deviceManager = new DeviceManager();
        for ( int i = 1; i <= deviceManager.DeviceInfos.Count; i++ ) // Loop Through the get List Of Devices.
        {
          if ( deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType ) // Skip device If it is not a scanner
          {
            continue;
          }
          lstListOfScanner.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
        }
      }
      catch ( COMException ex )
      {
        MessageBox.Show(ex.Message);
      }
      try
      {
        var deviceManager = new DeviceManager();
        DeviceInfo AvailableScanner = null;
        for ( int i = 1; i <= deviceManager.DeviceInfos.Count; i++ ) // Loop Through the get List Of Devices.
        {
          if ( deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType ) // Skip device If it is not a scanner
          {
            continue;
          }
          AvailableScanner = deviceManager.DeviceInfos[i];
          break;
        }
        var device = AvailableScanner.Connect(); //Connect to the available scanner.
        var ScanerItem = device.Items[1]; // select the scanner.
        var imgFile = (ImageFile)ScanerItem.Transfer();
        var data = (byte[])imgFile.FileData.get_BinaryData();
        var bitmap = GetBitmapFromRawData(imgFile.Width, imgFile.Height, data);
        var Path = @"C:\....\ScanImg.jpg"; // save the image in some path with filename.
        if ( File.Exists(Path) )
        {
          File.Delete(Path);
        }
        bitmap.Save(Path, ImageFormat.Jpeg);
      }
      catch ( COMException ex )
      {
        MessageBox.Show(ex.Message);
      }
