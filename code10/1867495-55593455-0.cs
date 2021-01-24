    switch (drainxy)
        {
        case "1":
        DisplayAlert(drainxy, "selected Value", "OK");
        drainPicker1();
        drain2Picker.IsVisible = false;
        drain3Picker.IsVisible = false;
        drain4Picker.IsVisible = false;
        break;
        case "2":
        DisplayAlert(drainxy, "selected Value", "OK");
        drainPicker1.IsVisible = true;
        drainPicker2.IsVisible = true;
        drain3Picker.IsVisible = false;
        drain4Picker.IsVisible = false;
        break;
        }
     }
