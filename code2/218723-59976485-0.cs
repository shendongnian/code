    private List<Control> getControls()
    {
        List<Control> lControls = new List<Control>();
        foreach (Control oControl in Page.Controls)
            foreach (Control childControl1 in oControl.Controls)
                foreach (Control childControl2 in childControl1.Controls)
                    foreach (Control childControl3 in childControl2.Controls)
                        if (childControl3.GetType().ToString().Contains("System.Web.UI.WebControls"))
                            lControls.Add(childControl3);
        return lControls;
    }
