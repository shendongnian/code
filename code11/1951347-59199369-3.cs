     List<string> names = new List<string>();
     // These are the radio buttons we are looking for
     // You would need to change the last three numbers to either target r1 or r2 
     names.AddRange(new[] { "dynamicr11", "dynamicr21" });
     // Get all controls that matches our type and any names
     var c = flowLayoutPanel1.GetControls(typeof(RadioButton), names);
     string r21Value = c?.Where(ctl => ctl.Name == "dynamicr21").Select(ctl => ctl.Text).FirstOrDefault();
