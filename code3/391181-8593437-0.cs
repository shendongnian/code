    public class ConsoleForm : Form {
      private int _FormID;
      public ConsoleForm(int formID) {
        _FormID = formID;
        this.Text = "Console #" + _FormID.ToString();
      }
      public int FormID {
        get { return _FormID; }
      }
    }
