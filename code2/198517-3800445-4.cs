    public static Form IsFormAlreadyOpen(Type FormType)
    {
        foreach (Form OpenForm in Application.OpenForms)
        {
            if (OpenForm.GetType() == FormType)
                return OpenForm;
        }
        return null;
    }
    private void ClickEvent<T>(object sender, EventArgs e) where T: Form, new() 
		{
        T f1 = null;
        if (IsFormAlreadyOpen(typeof(T)) == null)
        {
            f1 = new Form1();
            f1.MdiParent = this;
            f1.Show();
        }
        else
        {
            Form selectedForm = IsFormAlreadyOpen(typeof(T));
            foreach (Form OpenForm in this.MdiChildren)
            {
                if (OpenForm == selectedForm)
                {
                    if (selectedForm.WindowState == FormWindowState.Minimized)
                    {
                        selectedForm.WindowState = FormWindowState.Normal;
                    }
                    selectedForm.Select();
                }
            }
        }
    }
		
		private void form1ToolStripMenuItem_Click(object sender, EventArgs e) 		{
			ClickEvent<Form1>(sender, e)
		}
    
    private void form2ToolStripMenuItem_Click(object sender, EventArgs e) {
       ClickEvent<Form1>(sender, e) 
    }
