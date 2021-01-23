    using System;
    using System.Web;
    using System.Web.UI.WebControls;
    
    public partial class CustomControlClass : System.Web.UI.UserControl {
      private int _myValue= -1;
      public int myValue {
        get { return _myValue; }
        set { _myValue= value; }
      }
      private Literal _litTest;
      public Literal litTest {
        get { return _litTest; }
        set { _litTest= value; }
      
      }
      protected override void  OnInit(EventArgs e) {
        base.OnInit(e);
        litTest.Text = "TEST";
      }
    }
