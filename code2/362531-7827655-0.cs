     protected void FormView1_DataBound(object sender, EventArgs e)
     {
            if (FormView1.CurrentMode == FormViewMode.Edit)
            {
                FindAllTextBoxes(FormView1);
            }
     }
     private void FindAllTextBoxes(Control parent)
     {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    TextBox tbox = c as TextBox;
                    if (tbox != null)
                    {
                        // textbox found ....you could send this textbox, by reference to another procedure that assigns the values comparing
                        //it by tbox.ID
                    }
                }
                if (c.Controls.Count > 0)
                {
                    FindAllTextBoxes(c);
                }
            }
      }
    
