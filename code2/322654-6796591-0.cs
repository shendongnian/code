        CustomControl cc = yourCustomControl;
        cc.SelectionCompleted += (sender, args) => { YourMethod() };
     This is using an anomynous event handler using a lambda.
     Another way would be:
        public class Form1 : Form
        {
           public Form1()
           {
              this.cc.SelectionCompleted += HandlerSelectionCompleted;
           }
           public void HandlerSelectionCompleted(object sender, EventArgs e)
           {
              YourCustomMethod();
           }
        }
