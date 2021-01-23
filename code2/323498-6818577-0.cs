    // base class with common functionality
    public class MyUserControlBase : UserControl {
        // derived class will initialize this property
        public TextBox TextBox1 {get;set;}
        // derived class will initialize this property
        public Button Button1 {get;set;}
    
        /* some code of usercontrol */
    }
    
    /* ... elsewhere ... */
    // final class with *.aspx file
    public class MyUserControlA : MyUserControlBase {
        protected override OnInit(EventArgs e) {
            // "this.txtUrl" is generated from *.aspx file
            this.TextBox1 = this.txtUrl;
            // "this.btnSubmit" is generated from *.aspx file
            this.Button1 = this.btnSubmit;
        }
    }
    
    /* ... elsewhere ... */
    // final class with *.aspx file
    public class MyUserControlB : MyUserControlBase {
        protected override OnInit(EventArgs e) {
            // "this.txtTitle" is generated from *.aspx file
            this.TextBox1 = this.txtTitle;
            // "this.btnOk" is generated from *.aspx file
            this.Button1 = this.btnOk;
        }
    }
