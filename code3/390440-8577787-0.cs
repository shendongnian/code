    public class ToolStripDropDownEx : ToolStripDropDown {
      protected override bool ProcessDialogKey(Keys keyData) {
        if (keyData == Keys.Escape)
          return true;
        else
          return base.ProcessDialogKey(keyData);
      }
    }
