    public static SetChildEnabled(this WebControl parent) {
        foreach (WebControl ctl in parent.Controls) {
             ctl.Enabled = parent.Enabled;
        }
    }
