    try
      {
        Conn.Open();
        MessageBox.Show("Oracle Connection Established", "Success");
      }
      catch (OracleException ex)
      {
        MessageBox.Show(ex.Message, "Oracle Connection Failed!");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Oracle Connection Failed!");
      }
      finally
      {
        Conn.Close();
        MessageBox.Show("Oracle Connection Closed", "Success");
      }
