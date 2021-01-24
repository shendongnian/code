    var matches = new List<IDevice>();
    foreach ( var device in devices )
      if ( device is BatteryDevice )
      {
        var battery = (BatteryDevice)device;
        if ( battery.Id == "Battery1" && battery.StateOfCharge > 95 )
          matches.Add(battery);
      }
