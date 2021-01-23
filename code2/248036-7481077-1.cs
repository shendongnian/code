    using System;
    using System.Collections.Generic;
    using System.Web;
    
    /// <summary>
    /// Summary description for SomeClassInApp_Code
    /// </summary>
    public class SomeClassInApp_Code
    {
        public static System.Web.UI.Control GetNewUserControl(string someString)
        {
            BaseMyControls bc = (BaseMyControls)(new System.Web.UI.UserControl()).LoadControl("~/controls/MyUC.ascx");
            bc.strProperty = someString;
            return bc;
        }
    }
    
