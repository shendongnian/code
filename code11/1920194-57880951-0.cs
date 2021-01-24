    if (currentType.Name == "List`1")
    {
        var list = currentValue as List<Calibration.Camera>;
        if (list == null) throw new ArgumentException("currentType and currentValue do not match.");
        foreach (var camera in list)
        {
            cbox = new CheckBox
            {
                Text = "[" + i.ToString() + "]",
                Name = prev_properties + "!" + curr_property,
                AutoSize = true,
                Location = new Point(1100 + prop_list.Count() * 100, i++ * 20) //vertical
            };
            cbox.CheckedChanged += new EventHandler(ck_CheckedChanged);
            this.Controls.Add(cbox);               
        }
    }
