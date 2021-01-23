     public class MyForm : Form {
          
          Control body;
          public void HandleUserAction(string action) {
              if (body != null) this.Controls.Remove(body);
              if (action == "goto1") {
                 body = new MyUserControl();
              }
              // Handle other actions
              if (body == null) return;
              this.Controls.Add(body);
          }
     }
     // In your control
     public MyCtl : UserControl {
           public void Button1_Click(object sender, EventArgs e) {
               ((MyForm)FindForm()).HandleUserAction("goto1");
           }
     }
