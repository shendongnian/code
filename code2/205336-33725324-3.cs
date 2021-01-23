    class Form1 : Form, IForm {
       public Form1() {
         Controls.Add(new Foo(this));
       }
       // Required to be defined here.
       void IForm.Button_OnClick(object sender, EventArgs e) {
         ...
       }
     }
