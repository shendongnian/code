    private void m_DateTimePickerEndTime_Leave(object sender, EventArgs e)
    {    
      this.Focus();      
      SetDuration((int(m_DateTimePickerEndTime.Value.Subtract
              (m_DateTimePickerStartTime.Value).TotalMinutes));    
    }
