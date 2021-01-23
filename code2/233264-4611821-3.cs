    public static Form frm { get; set; }
    static void UtilScenario()
    {
        HideController();
    }
    internal static void HideController()
    {
        if (frm == null)
            return;
        DialogResult dlgResult = MessageBox.Show("Controller will now close.", "Closing...",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        if (dlgResult == DialogResult.OK)
        {
            frm.Hide();
        }
    }
