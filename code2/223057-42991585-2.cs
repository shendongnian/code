    void MdiClient_ControlAdded(object sender, ControlEventArgs e)
    {
        if (e.Control is Form)
            {
                var form = e.Control as Form;
                form.FormClosing += form_FormClosing;
                form.FormClosed += form_FormClosed;
            }
    }
