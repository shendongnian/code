    static class Program
    {
      [STAThread]
      static void Main()
      {
          Main main;
          do
          {
             main = new Main();
          } while (DialogResult.OK == main.ShowDialog ());
      }
    } 
    private void ChangeUsers()
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }   
