    private System.WinForms.ToolTip m_wndToolTip;
    
    this.m_wndToolTip = new System.WinForms.ToolTip (this.components);
    
    m_wndToolTip.SetToolTip (PictureButton, "Click Me!");
    m_wndToolTip.SetToolTip (m_wndIntTextBox, "Enter Integer data type value.");
