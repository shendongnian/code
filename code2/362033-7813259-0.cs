    public class Form2 : ... {
      main ma;
      public Form2(main ma) {
        this.ma = ma;
      }
      private void Button1_Click(object sender, EventArgs e) {
        this.ma.AddType(txtName.Text, txtUrl.Text, 12);
        this.Close();
      }
    }
