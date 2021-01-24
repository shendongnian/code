     List<string> names = new List<string>();
     names.AddRange(new[] { "dynamicr0", "dynamicr20" });
     var c = flowLayoutPanel1.GetControls(typeof(RadioButton), names);
     bool? r1Value = c?.Where(ctl => ctl.Name == "dynamicr0").Select(ctl => ((RadioButton)ctl).Checked).FirstOrDefault();
     bool? r21Value = c?.Where(ctl => ctl.Name == "dynamicr20").Select(ctl => ((RadioButton)ctl).Checked).FirstOrDefault();
