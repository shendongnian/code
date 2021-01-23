    protected void btn_Click(object sender, EventArgs e)
    {
        Table t = (Table)PName_placeholder.Controls.FindControls("PassengerTable");
        string pname = "";
        foreach (TableRow tr in t.Rows)
        {
            foreach (TableCell tc in tr.Cells)
            {
                foreach (Control c in tc.Controls)
                {
                  if (c is TextBox && c.ID.StartsWith("txtname"))
                  {
                          pname = ((TextBox)t.FindControl(c.ID)).Text;
                          Session["pname1"] = pname;
                  }
             }
         }
    }
