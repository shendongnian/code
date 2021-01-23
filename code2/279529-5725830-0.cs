    try
    {
      rvals = _opcServer[serverID1 - 1].Read(array1, Convert.ToInt32(dt1["refreshRate"]));
    }
    catch (System.Exception ex)
    {
      System.Windows.Forms.MessageBox.Show("Exception: " + ex.GetType().ToString() +
        "\r\nMessage: " + ex.Message);
    }
