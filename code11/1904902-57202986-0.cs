    foreach (Device devicePrimary in MyProject1.Devices)
    {
        Device Prim = null;
        Device Sec = null;
        foreach (Device deviceSecondary in MyProject2.Devices)
        {
          //your code
        }
        if( Prim != Sec)
        {
            textBox1.Text = "Device does not exist in both projects.";
        }
    }
