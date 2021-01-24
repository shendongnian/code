    static private Dictionary<int, EmployeeInfoPopup> EmployeeInfoForms 
      = new Dictionary<int, EmployeeInfoPopup>();
    private void EmployeeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = EmployeeListBox.SelectedIndex;
      if ( EmployeeInfoForms.ContainsKey(index) )
      {
        EmployeeInfoForms[index].Show();
      }
      else
      {
        EmployeeInfoPopup popup = new EmployeeInfoPopup();
        EmployeeInfoForms.Add(index, popup);
        popup.employeePopupLayout(index);
        popup.Show();
      }
    }
    static internal void EmployeeInfoPopupClosed(EmployeeInfoPopup sender)
    {
      var key = EmployeeInfoForms.FirstOrDefault(v => v.Value == sender).Key;
      if ( key != null )
        EmployeeInfoForms.Remove(key);
    }
