    internal static void HideController(Form frm)
                {
                    DialogResult dlgResult = MessageBox.Show("Controller will now close.", "Closing...",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
                    if (dlgResult == DialogResult.OK)
                    {
                        frm.Hide();
                    }
                }
