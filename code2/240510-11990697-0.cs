    public class MyComboBox : System.Windows.Forms.ComboBox
    {
      private bool _sendSic;
      protected override void OnPreviewKeyDown(System.Windows.Forms.PreviewKeyDownEventArgs e)
      {
        base.OnPreviewKeyDown(e);
        if (DroppedDown)
        {
          switch(e.KeyCode)
          {
            case System.Windows.Forms.Keys.Escape:
              _sendSic = true;
              break;
            case System.Windows.Forms.Keys.Tab:
            case System.Windows.Forms.Keys.Enter:
              if(DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
                _sendSic = true;
              break;
          }
        }
      }
      protected override void OnDropDownClosed(System.EventArgs e)
      {
        base.OnDropDownClosed(e);
        if(_sendSic)
        {
          _sendSic = false;
          OnSelectedIndexChanged(System.EventArgs.Empty);
        }
      }
    }
