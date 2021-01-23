    private void EmployeeMouseHoverToolTip(object sender, EventArgs e) {  
      var txtBox = (C1TextBox)sender;
      var toolTipText = ResolveUpdatedTooltipText(txtBox.Text);
      c1SuperTooltip.SetToolTip(txtBox, toolTipText);
    }
    
    private string ResolveUpdatedTooltipText(string sUserIdentifier) {
      var userIdentifier = ResolveGuid(sUserIdentifier);
      return Utilities.UserIdentifierToName(userIdentifier);
    }
    private Guid ResolveGuid(string sUserIdentifier) {
      return Utilities.IsGuid(sUserIdentifier) ? 
        new Guid(sUserIdentifier) : 
        Guid.Empty;
    }
    
