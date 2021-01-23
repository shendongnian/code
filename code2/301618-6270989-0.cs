    private bool fIsInEvent = false;
    
    private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!fIsInEvent)
      {
        fIsInEvent = true;
        try
        {
          // your code
        }
        finally { fIsInEvent = false; }
      }
    }
