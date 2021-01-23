    public class MainForm
    {
      private void OnEditClick()
      {
        EditForm editForm = new EditForm();
        DialogResult result = editForm.ShowDialog(this);
        //check the result for ok/cancel etc if your using them.
        whatever = editForm.TextBox1;
        whatever2 = editForm.TextBox2;
    }
    public class EditForm
    {
      public string TextBox1 { get { return textBox1.Text;} }
      public string TextBox2 { get { return textBox2.Text;} }
      // etc
    }
