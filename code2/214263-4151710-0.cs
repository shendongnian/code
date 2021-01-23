    var controls = (from Control control in this.Controls
                   select control.GetType().ToString()).Distinct();
    
    foreach (var x in controls)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(x);
        listBox2.Items.Add(sb.ToString());
    }
