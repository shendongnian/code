    using System.Web;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    /// <summary>
    /// Summary description for ControlHelper
    /// </summary>
    public static class ControlHelper
    {
        // Example: HtmlForm form = ControlHelper.FindControlRecursive(this.Master, "form1") as HtmlForm;
        /// <summary>
        /// Finds a Control recursively. Note finds the first match and exits
        /// </summary>
        /// <param name="ContainerCtl"></param>
        /// <param name="IdToFind"></param>
        /// <returns></returns>
        public static Control FindControlRecursive(this Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;
    
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
    
            return null;
        }
        //ModifyControl<TextBox>(this, tb => tb.Text = "test");
        public static void ModifyControl<T>(this Control root, Action<T> action) where T : Control
        {
            if (root is T)
                action((T)root);
            foreach (Control control in root.Controls)
                ModifyControl<T>(control, action);
        }
    }
