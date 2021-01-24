    //...omitted for brevity
    var json = await result.Content.ReadAsStringAsync();
    try {
        vehicRec = Newtonsoft.Json.JsonConvert.DeserializeObject<VehicleRecord>(json);
        if(vehicRec == null) {
            //check for an array just in case
            var items = JsonConvert.DeserializeObject<VehicleRecord[]>(json);
            if(items != null && items.Length > 0) {
                vehicRec = items[0];
            }
        }
    }
    catch (Exception ex) { }
    if (vehicRec == null)
    {
        Toast.MakeText(this, json, ToastLength.Short).Show();
    }
    else
    {
        firstName.Text = vehicRec.firstName;
        lastName.Text = vehicRec.lastName;
        gen.Text = vehicRec.gender;
        ic.Text = vehicRec.icNo;
        address.Text = vehicRec.address;
        phoneNo.Text = vehicRec.phoneNo;
        username.Text = vehicRec.username;
        password.Text = vehicRec.password;
        payment.Text = vehicRec.paymentMethod;
    }
    //...omitted for brevity
