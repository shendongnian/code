    foreach (Device devicePrimary in MyProject1.Devices)
    {
        string Prim = String.Empty;
        string Sec = String.Empty;
        foreach (Device deviceSecondary in MyProject2.Devices)
        {
          //your code
        }
        if( Prim != Sec)
        {
            textBox1.Text = "Device does not exist in both projects.";
        }
    }
