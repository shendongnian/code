     protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
     {  
        string lbl_nam = (Label)GridView1.Rows[GridView1.SelectedIndex].FindControl("Label_nam");
        string nam = NAM.Text;
      }
           
