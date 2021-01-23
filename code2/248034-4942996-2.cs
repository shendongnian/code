    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public class MyClass {
      public static void doWork(Page Ctrl) {
        CustomControlClass c = 
          (CustomControlClass) Ctrl.LoadControl("~/controls/testControl.ascx");
        c.myValue = 1;
        Ctrl.Form.Controls.Add(c);
    
        Literal l = new Literal();
        l.Text = string.Format(
          "<p>CustomControlClass.myValue: {0} </p>", 
          c.myValue
        )
        + string.Format(
          "<p>CustomControlClass.litTest.Text: {0} </p>", 
          c.litTest.Text
        )
        ;
        Ctrl.Form.Controls.Add(l);
      }
    }
