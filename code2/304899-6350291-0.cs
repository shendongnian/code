    public class Form1
    {
       ...
       public void ShowAdminForm2()
       {
          if (!chkAdmin.IsChecked)
             MessageBox.Show ("Not admin");
          else
             new Form2().ShowDialog();
       }
    }
