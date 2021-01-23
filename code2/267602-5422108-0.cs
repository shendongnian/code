    using System.Windows.Forms;
    private void EnableSip()
    {
              SoftKeyboard.CurrentInputMethod = SoftKeyboard.CurrentInputMethod;
              SoftKeyboard.Enabled = true;
              SoftInputPanel.ShowSIP(true, this);
    }
    private void DisableSip()
     {
              SoftKeyboard.Enabled = false;
              SoftInputPanel.ShowSIP(false, this);
     }
