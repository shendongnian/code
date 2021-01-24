    this.entites.Ponds.Where ( 
       e => e.Device.Customer.Username == "user1" ||
            e.Device.DeviceId == 1
    )
    .Select( e => new { temp = e.Temp, imei = e.Imei,timestamp=e.Timestatmp })
    .FirstOrDefaultAsync();
