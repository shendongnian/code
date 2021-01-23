    public class MyTextBox : System.Windows.Forms.TextBox
     {
        public void MyCustomMethod() { ... }
        public override void OnLoad(EventArgs e) 
         { base.OnLoad(e);
           ...
         }
     }
