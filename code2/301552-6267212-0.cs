    class FormB : Form
    {
        FormB(FormA parent)
        { 
            this.Parent = parent;
        }
        ...
     
        protected void btnB_Click(object sender, EventArgs e)
        {
           parent.RefreshGrid();
           this.Close();
        }
    }
