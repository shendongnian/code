    /// <summary>
    /// Find all com ports that contain the given friendly device name. i.e.
    /// AutofindComPort("Prolific") would return a list with the values "COM1",
    /// and "COM3". If the device manager listed
    /// "Prolific USB-to-Serial Comm Port (COM1)" and
    /// "Prolific USB-to-Serial Comm Port (COM3)".
    /// </summary>
    /// <param name="deviceName">The friendly name of the device to find com
    /// ports for.</param>
    /// <returns>The com port names the device(s) are attached to.</returns>
    private List<string> AutofindComPort(string deviceName)
    {
      List<ManagementBaseObject> devs = GetDevices(deviceName);
      // Get the com ports from the ManagementBaseObject.
      List<string> comnames = new List<string>();
      foreach (ManagementBaseObject dev in devs)
      {
        comnames.Add(
          ParsePortNameFromFriendlyName((string)dev.GetPropertyValue("Name")));
      }
      return comnames;
    }
    /// <summary>
    /// Search through the devices connected to the computer, looking for any
    /// that contain the given device name and "COM" in their friendly name.
    /// </summary>
    /// <returns>All of the matching devices found.</returns>
    private List<ManagementBaseObject> GetDevices(string deviceName)
    {
      // Getting a list of all available com port devices and their friendly
      // names. source:   
      // http://www.codeproject.com/KB/system/hardware_properties_c_.aspx   
      List<ManagementBaseObject> devices = new List<ManagementBaseObject>();
      using (ManagementObjectSearcher searcher
        = new ManagementObjectSearcher("Select * from Win32_PnpEntity"))
      {
        foreach (ManagementBaseObject device in searcher.Get())
        {
          object nameo = device.GetPropertyValue("Name");
          if (nameo != null)
          {
            string name = (nameo as string);
            // Only add item if the friendly names contains "COM" and the device
            // name we want.
            if (name.Contains("(COM") && name.Contains(deviceName))
            {
              devices.Add(device);
            }
          }
        }
      }
      return devices;
    }
    /// <summary>
    /// Parse the port name ("COM30") from the friendly device name ("Prolific
    /// USB-to-Serial Comm Port (COM30)").
    /// </summary>
    /// <param name="friendlyName">The friendly device name to parse.</param>
    /// <returns>The com port name.</returns>
    private string ParsePortNameFromFriendlyName(string friendlyName)
    {
      Match m = Regex.Match(friendlyName, @".*\((COM\d+)\).*");
      if (m.Success)
      {
        return m.Groups[1].Captures[0].Value;
      }
      else
      {
        return string.Empty;
      }
    }
